using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponManager : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab1;
    [SerializeField] private GameObject bulletPrefab2;
    [SerializeField] private GameObject bulletPrefab3;

    public Shooting playerShoot;
    public SpriteRenderer sprite;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetWeapon(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetWeapon(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SetWeapon(3);
        }
    }

    void SetWeapon(int weaponID)
    {
        switch (weaponID) 
        { 
            case 1:
                playerShoot.Shoot(bulletPrefab1);
                break;
            case 2:
                playerShoot.Shoot(bulletPrefab2);
                break;
            case 3:
                playerShoot.Shoot(bulletPrefab3);
                break;
        }
    }

    void ChangeWeaponPlayer()
    {
         
    }
}
