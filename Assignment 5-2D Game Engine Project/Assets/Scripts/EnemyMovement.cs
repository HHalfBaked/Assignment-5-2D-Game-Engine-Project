using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
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
            targetDirection = playerAwarenessController.DirectionToPlayer;
            anim.SetBool("IsMoving", true);
        }
        else
        {
            targetDirection = Vector2.zero;
            anim.SetBool("IsMoving", false);
        }
    }
    private void RotateTowardsTarget()
    {
        if (targetDirection == Vector2.zero) 
        {
            return;        
        }
        Quaternion targetRotation = Quaternion.LookRotation(transform.forward, targetDirection);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        rigidbody.SetRotation(rotation);
    }
    private void SetVelocity()
    {
        if (targetDirection == Vector2.zero)
        {
            rigidbody.velocity = Vector2.zero;
        }
        else
        {
            rigidbody.velocity = transform.up * speed;
        }
    }
}
