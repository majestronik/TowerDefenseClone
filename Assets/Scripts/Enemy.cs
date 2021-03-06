using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;
    [HideInInspector]
    public float speed;
    public float startHealth = 100f;
    private float health;
    public int worth = 50;
    public GameObject deathEffect;
    [Header("Unity Stuff")]
    private bool isDead = false;
    public Image healthBar;

    void Start()
    {
        speed = startSpeed;
        health = startHealth;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        healthBar.fillAmount = (health / startHealth);
        if (health <= 0 && !isDead)
        {
            Die();
        }
    }

    private void Die()
    {
        isDead = true;
        PlayerStats.Money += worth;
        Destroy(gameObject);
        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        WaveSpawner.EnemiesAlive--;
    }

    private void Update()
    {

    }

    public void Slow(float pct)
    {
        speed = startSpeed * (1f - pct);
    }
}
