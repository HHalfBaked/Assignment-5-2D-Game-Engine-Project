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
    public float reloadDelay = 0.7f;
    public float shootDelay = 0.4f;

    private bool canShoot = true;
    private bool isReloading = false;

    void Update()
    {
        if(Input.GetButtonDown("Fire1") && currentClip > 0 && canShoot == true && isReloading == false)
        {
            canShoot = false;
            ShootHandGun(bulletPrefab);
            anim.SetBool("IsShoot", true);
            currentClip -= 1;
            StartCoroutine(ResetShootAfterDelay(shootDelay));
        }
        else 
        {
            anim.SetBool("IsShoot", false);
        }
        if(Input.GetKeyDown(KeyCode.R) && currentClip != maxClipSize)
        {
            isReloading = true;
            canShoot = false;
            Reload();
            anim.SetBool("IsReload", true);
            StartCoroutine(ResetBoolAfterDelay(reloadDelay));
        }
    }

    public void ShootHandGun(GameObject bulletPrefab1)
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
        canShoot = true;
        isReloading = false;
    }
    IEnumerator ResetShootAfterDelay(float shootDelay)
    {
        yield return new WaitForSeconds(shootDelay);
        canShoot = true;
    }
}
