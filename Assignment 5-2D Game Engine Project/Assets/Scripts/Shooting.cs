using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public Animator anim;

    public float bulletForce = 20f;

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot(bulletPrefab);
            anim.SetBool("IsShoot", true);
        }
        else
        {
            anim.SetBool("IsShoot", false);
        }
    }
    public void Shoot(GameObject bulletPrefab1)
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }


}
