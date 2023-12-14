using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    //Variables
    public int health;
    public int maxHealth = 100;
    public HealthBar healthBar;
    public Animator anim;
    public float deathDelay = 1f;
    public bool isDead = false;

    void Start()
    {
        //Set health to max on awake up
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damageAmount)
    {
        //Reduce health 
        health -= damageAmount;
        //Set slider equal to health lost
        healthBar.SetHealth(health);

        if (health <= 0)
        {
            //Kills player
            anim.SetBool("IsDead", true); //Changes Animations
            isDead = true;
            StartCoroutine(DeathAfterDelay(deathDelay)); //Timer
        }
    }
    public void GainHealth(int healAmount)
    {
        //Checks if health isn't over max
        if (maxHealth > health)
        {
            //Add to health
            health += healAmount;
            healthBar.SetHealth(health); //Set Slider equal to health gain
        }
    }
    IEnumerator DeathAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); //Function continues after delay
        Debug.Log("Death");
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex); //Reloads the scene

        isDead = false;
        anim.SetBool("IsDead", false); //Changes animation
    }
}

