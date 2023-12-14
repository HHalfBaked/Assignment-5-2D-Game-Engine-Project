using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    //Variables
    public Transform firePoint;
    public GameObject bulletPrefab;
    public Animator anim;
    public PlayerHealth health;

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
        //When player isn't dead
        if (health.isDead == false)
        {
            if (Input.GetButtonDown("Fire1") && currentClip > 0 && canShoot == true && isReloading == false) 
            {
                canShoot = false; //Set bool for delay
                ShootHandGun(bulletPrefab); //Function call
                anim.SetBool("IsShoot", true); //Changes animation
                currentClip -= 1; //Reduce ammo in clip
                StartCoroutine(ResetShootAfterDelay(shootDelay)); //Starts shoot delay timer
            }
            else
            {
                anim.SetBool("IsShoot", false); // Changes animation
            }
            if (Input.GetKeyDown(KeyCode.R) && currentClip != maxClipSize)
            {
                isReloading = true; //Set bool for reload
                canShoot = false; //Disable shoot for reload
                Reload(); //Call function
                anim.SetBool("IsReload", true); //Change animtion
                StartCoroutine(ResetBoolAfterDelay(reloadDelay)); //Starts reload delay timer 
            }
        }
    }

    public void ShootHandGun(GameObject bulletPrefab1)
    {
        if (currentClip > 0)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation); //Create instance of bullet prefab at shootpoint
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>(); //Get its rigidbody
            rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse); //Apply force to prefab
        }
    }

    public void Reload()
    {
        int reloadAmount = maxClipSize - currentClip; //How many bullets to refill clip
        //Changes reload amount if ammo reserve doesn't have enough to fill clip 
        reloadAmount = (currentAmmo - reloadAmount) >= 0 ? reloadAmount : currentAmmo; 
        currentClip += reloadAmount; //Increase clip by reload amount
        currentAmmo -= reloadAmount; //Decrease reserve by reload amount
    }

    public void AddAmmo(int ammoAmount)
    {
        //Increase ammo reserve
        currentAmmo += ammoAmount;
        //Checks if ammo is going over max ammo
        if(currentAmmo > maxAmmoSize)
        {
            currentAmmo = maxAmmoSize; //Set ammo to max
        }    
    }
    //Delay function
    IEnumerator ResetBoolAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); //Waits delay time before rest of the function
        anim.SetBool("IsReload", false); //Changes animation
        canShoot = true; //Lets player shoot
        isReloading = false; //Lets player reload
    }
    IEnumerator ResetShootAfterDelay(float shootDelay)
    {
        yield return new WaitForSeconds(shootDelay); //Waits delay time before rest of the function
        canShoot = true;//Lets player shoot
    }
}
