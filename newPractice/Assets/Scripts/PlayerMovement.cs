using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour
{
    //speed

    [SerializeField]
    private float speed = 5f;

    [SerializeField]
    private float jumpSpeed = 10f;

    [SerializeField]
    private Collider2D GroundSensor = null;

    [SerializeField]
    private LayerMask GroundLayer = 0;

    [SerializeField]
    private Joystick myJoystick = null;

    private Rigidbody2D physicsBody = null;

    //unity functions
    private void Awake()
    {
        //getting the rigidbody2d component attached to the same object as this script (player)
        physicsBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        //make a variable to hold velocity
        //get current velocity from physics component
        Vector2 newVelocity = physicsBody.velocity;

        //set velocity to move in the direction our joystick is pressed
        newVelocity.x = speed * myJoystick.Horizontal;

        //update physics component's velocity to be our newly changed value
        physicsBody.velocity = newVelocity;
    }

    //user defined functions
    public void MoveLeft()
    {
        //make a variable to hold velocity
        //get current velocity from physics component
        Vector2 newVelocity = physicsBody.velocity;

        //set velocity to move in -x direction (left)
        newVelocity.x = -speed;

        //update physics component's velocity to be our newly changed value
        physicsBody.velocity = newVelocity;
    }
    public void MoveRight()
    {
        //make a variable to hold velocity
        //get current velocity from physics component
        Vector2 newVelocity = physicsBody.velocity;

        //set velocity to move in -x direction (left)
        newVelocity.x = speed;

        //update physics component's velocity to be our newly changed value
        physicsBody.velocity = newVelocity;
    }
    public void Jump()
    {
        //check if we are touching the ground
        if (GroundSensor.IsTouchingLayers(GroundLayer))
        {
            //make a variable to hold velocity
            //get current velocity from physics component
            Vector2 newVelocity = physicsBody.velocity;

            //set velocity to move in positive y direction (up)
            newVelocity.y = jumpSpeed;

            //update physics component's velocity to be our newly changed value
            physicsBody.velocity = newVelocity;
        }
    }
}
