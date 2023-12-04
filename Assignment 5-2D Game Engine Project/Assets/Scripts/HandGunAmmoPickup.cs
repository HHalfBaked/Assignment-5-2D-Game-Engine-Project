using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGunAmmoPickup : MonoBehaviour
{
    public Shooting shoot;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            shoot.AddAmmo(10);
            Destroy(gameObject);
        }
    }
}
