using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    //Variables
    public PlayerHealth heal;
    public int healAmount;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Increase health
            heal.GainHealth(healAmount);
            Destroy(gameObject);
        }
    }
}
