using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int maxHealth = 100;
    public HealthBar healthBar;
    public Animator anim;
    public float deathDelay = 1f;
    public bool isDead = false;

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
            anim.SetBool("IsDead", true);
            isDead = true;
            StartCoroutine(DeathAfterDelay(deathDelay));
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
    IEnumerator DeathAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Debug.Log("Death");
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);

        isDead = false;
        anim.SetBool("IsDead", false);
    }
}

