using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //Variables
    [SerializeField]
    private float speed;

    [SerializeField]
    private float rotationSpeed;

    private new Rigidbody2D rigidbody;
    private PlayerAwarenessController playerAwarenessController;
    private Vector2 targetDirection;
    public Animator anim;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        playerAwarenessController = GetComponent<PlayerAwarenessController>();
    }
    private void FixedUpdate()
    {
        UpgradeTargetDirection();
        RotateTowardsTarget();
        SetVelocity();
    }
    private void UpgradeTargetDirection()
    {
        if (playerAwarenessController.AwareOfPlayer) 
        {
            //Set direction to player position
            targetDirection = playerAwarenessController.DirectionToPlayer;
            anim.SetBool("IsMoving", true); // Change animation
        }
        else
        {
            //Keep direction at zero
            targetDirection = Vector2.zero;
            anim.SetBool("IsMoving", false); // Change animation
        }
    }
    private void RotateTowardsTarget()
    {
        if (targetDirection == Vector2.zero) //Checks if enemy is still
        {
            return;        
        }
        Quaternion targetRotation = Quaternion.LookRotation(transform.forward, targetDirection);//Sets target rotation
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime); //Sets rotation for gameobject
        rigidbody.SetRotation(rotation); //Updates gameobjects rotation
    }
    private void SetVelocity()
    {
        if (targetDirection == Vector2.zero) //When there is no targetDirection
        {
            rigidbody.velocity = Vector2.zero; //Stay still
        }
        else
        {
            rigidbody.velocity = transform.up * speed; //Move forward
        }
    }
}
