using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAwarenessController : MonoBehaviour
{
    //Variables
    public bool AwareOfPlayer;
    public Vector2 DirectionToPlayer;
    [SerializeField]
    private float playerAwarenessDistance;

    private Transform player;

    private void Awake()
    {
        player = FindAnyObjectByType<PlayerMovement>().transform;
    }

    private void Update()
    {
        Vector2 enemyToPlayerVector = player.position - transform.position; //Set vector equal to distance between player and gameobject
        DirectionToPlayer = enemyToPlayerVector.normalized; //Normalized number
        //Checks if distance is equal to playerawareness distance
        if (enemyToPlayerVector.magnitude <= playerAwarenessDistance)
        {
            AwareOfPlayer = true;
        }
        else
        {
            AwareOfPlayer = false;
        }
    }
}
