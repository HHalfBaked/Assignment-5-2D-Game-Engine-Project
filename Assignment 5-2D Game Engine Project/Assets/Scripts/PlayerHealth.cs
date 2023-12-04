using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int maxHealth = 100;
    public HealthBar healthBar;

    void Start()
    {
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;

        healthBar.SetHealth(health);

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void GainHealth(int healAmount)
    {
        if (maxHealth > health)
        {
            health += healAmount;
            healthBar.SetHealth(health);
        }
    }
}
