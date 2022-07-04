using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    private Node target;
    public GameObject ui;
    public TextMeshProUGUI upgradeCost;
    public TextMeshProUGUI sellAmount;
    public Button upgradeButton;
    public void SetTarget(Node _target)
    {
        target = _target;
        transform.position = target.GetBuildPosition();
        if (!target.isUpgraded)
        {
            upgradeCost.text = "$" + target.turretBlueprint.upgradeCost;
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeCost.text = "DONE";
            upgradeButton.interactable = false;
        }
        sellAmount.text = "$" + target.turretBlueprint.GetSellAmount();

        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }
    public void Sell()
    {
        target.SellTurret();
        BuildManager.instance.DeselectNode();
    }
}
