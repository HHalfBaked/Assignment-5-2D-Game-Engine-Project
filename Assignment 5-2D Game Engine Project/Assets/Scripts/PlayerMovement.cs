using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Variables
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Camera cam;
    Vector2 movement;
    Vector2 mousePos;

    public Animator anim;
    public PlayerHealth health;

    void Update()
    {
        //Only move when not dead
        if (health.isDead == false)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            mousePos = cam.ScreenToWorldPoint(Input.mousePosition); //Set Vector2 to mouse position

            if (movement.x == 0 && movement.y == 0) //When not moving
            {
                anim.SetBool("IsMoving", false); //Changes animation
            }
            else
            {
                anim.SetBool("IsMoving", true); //Changes animation
            }
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime); //Move position
        
        Vector2 lookDirection = mousePos - rb.position; //Vector2 set to distance between player and mouse
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg; //Float set to X and Y axis
        rb.rotation = angle; //Rotate towards angle of mouse
    }
}
