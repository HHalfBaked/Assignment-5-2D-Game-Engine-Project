using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    //Variables
    [SerializeField] int health;
    [SerializeField] int maxHealth = 3;

    public int damage;
    public PlayerHealth playerHealth;
    public Animator anim;

    void Start()
    {
        health = maxHealth;
    }
    //Function to reduce health
    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerHealth.TakeDamage(damage); //Damage player health
            anim.SetBool("IsAttack", true); //Change animation
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.SetBool("IsAttack", false); //Change animation 
        }
    }
}
