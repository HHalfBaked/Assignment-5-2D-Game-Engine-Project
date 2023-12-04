using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public Animator anim;

    public float bulletForce = 20f;
    public int currentClip;
    public int maxClipSize = 10;
    public int currentAmmo;
    public int maxAmmoSize = 100;


    void Update()
    {
        if(Input.GetButtonDown("Fire1") && currentClip > 0)
        {
            Shoot(bulletPrefab);
            anim.SetBool("IsShoot", true);
            currentClip -= 1;
        }
        else 
        {
            anim.SetBool("IsShoot", false);
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            Reload();
            anim.SetBool("IsReload", true);
            StartCoroutine(ResetBoolAfterDelay(0.2f));
        }
    }
    public void Shoot(GameObject bulletPrefab1)
    {
        if (currentClip > 0)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        }
    }

    public void Reload()
    {
        int reloadAmount = maxClipSize - currentClip;
        reloadAmount = (currentAmmo - reloadAmount) >= 0 ? reloadAmount : currentAmmo;
        currentClip += reloadAmount;
        currentAmmo -= reloadAmount;
    }

    public void AddAmmo(int ammoAmount)
    {
        currentAmmo += ammoAmount;
        if(currentAmmo > maxAmmoSize)
        {
            currentAmmo = maxAmmoSize;
        }    
    }

    IEnumerator ResetBoolAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        anim.SetBool("IsReload", false);
    }
}
