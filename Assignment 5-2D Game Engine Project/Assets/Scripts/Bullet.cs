using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //Variables
    public GameObject hitEffect;
    public float effectDur;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Get enemy health compenent
        if (collision.gameObject.TryGetComponent<EnemyHealth>(out EnemyHealth enemyComponent))
        {
            //Reduce health by 1
            enemyComponent.TakeDamage(1);
        }
        //Show hit effect
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, effectDur); 
        Destroy(gameObject);
    }
}
