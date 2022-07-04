using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 positionOffset;
    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBlueprint turretBlueprint;
    [HideInInspector]
    public bool isUpgraded;
    private Renderer rend;
    private Color startColor;
    BuildManager buildManager;
    public Color notEnoughMoneyColor;
    public Color cantBuildColor;

    public ParticleSystem upgradeEffect;
    public ParticleSystem sellEffect;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }


    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    void BuildTurret(TurretBlueprint blueprint)
    {
        if (PlayerStats.Money < blueprint.cost)
        {
            Debug.Log("Not enough money to build that!");
            return;
        }
        PlayerStats.Money -= blueprint.cost;

        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, this.transform.position, Quaternion.identity);
        turret = _turret;
        turretBlueprint = blueprint;

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, this.GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        Debug.Log("Turret build! ");
    }
    public void UpgradeTurret()
    {
        if (PlayerStats.Money < turretBlueprint.upgradeCost)
        {
            Debug.Log("Not enough money to upgrade that!");
            return;
        }
        PlayerStats.Money -= turretBlueprint.upgradeCost;

        // Get rid of the old turret
        //Destroy(turret);

        // Building a new one :)
        GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab,
            transform.position + new Vector3(0, 50, 0), Quaternion.identity);

        StartCoroutine(UpgradeCoroutine(_turret.transform, .2f));

        // GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        // Destroy(effect, 5f);
        isUpgraded = true;

        Debug.Log("Turret upgraded");
    }



    private IEnumerator UpgradeCoroutine(Transform _target, float t)
    {

        float time = 0;
        float pos = _target.position.y;
        Quaternion rot = turret.transform.rotation;
        while (time < 1)
        {
            time += Time.deltaTime * 1 / t;
            var value = Mathf.Lerp(pos, 0, time);
            _target.transform.position = new Vector3(_target.position.x, value, _target.position.z);
            _target.transform.rotation = rot;
            yield return new WaitForSeconds(.016f);
        }
        Destroy(turret);
        turret = _target.gameObject;
        ParticleSystem effect = Instantiate(upgradeEffect);
        effect.transform.position = GetBuildPosition();
        Destroy(effect, 2f);
    }
    internal void SellTurret()
    {
        Destroy(turret);
        ParticleSystem effect = Instantiate(sellEffect);
        effect.transform.position = GetBuildPosition();
        Destroy(effect, 2f);
        PlayerStats.Money += turretBlueprint.GetSellAmount();
        isUpgraded = false;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (turret != null)
        {
            buildManager.SelectNode(this);
            return;
        }
        if (!buildManager.CanBuild)
            return;

        BuildTurret(buildManager.GetTurretToBuild());
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.CanBuild)
            return;
        if (turret != null)
        {
            rend.material.color = cantBuildColor;
            return;
        }
        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughMoneyColor;
        }

    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
