using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Public variables to manipulate in Unity
    public float speed;
    public int jumpVelocity;
    public bool collCheck = false;

    //Private variables for movement
    private Rigidbody2D rigidB;
    private bool isJumping = false;
    
    //Called when the object is initialized
    private void Start()
    {
        rigidB = GetComponent<Rigidbody2D>();
    }

    //Called in a fixed interval -- best used when dealing with Physics
    private void Update()
    {
        //Get the input for the horizontal movement
        float moveHorizontal = Input.GetAxis("Horizontal");

        //If the space bar is pushed and the Shape Shifter isn't already jumping
        if (Input.GetKeyDown("space") && !isJumping)
        {
            //Set isJumping to true and set jump to the jumpHeight 
            isJumping = true;
            rigidB.velocity = new Vector2(rigidB.velocity.x, jumpVelocity);
        }
        //Create a new Vector2 with the given force directions -- add the force to the rigid body
        //Vector2 movement = new Vector2(moveHorizontal, 0);
        //rigidB.AddForce(movement * speed);
        rigidB.velocity = new Vector2(moveHorizontal * speed, rigidB.velocity.y);

    }

    /// <summary>
    /// On collision with a 2D object
    /// Primarily used to check for collision with a platform
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionStay2D(Collision2D collision)
    {
        //Collision check to see if the player is on the top of the collision object
        //collCheck = collision.gameObject.transform.position.y + (collision.gameObject.transform.lossyScale.y / 2) <= transform.position.y - (transform.lossyScale.y / 2);
        collCheck = IsGrounded();
        //If the player collided with the floor
        if(collision.gameObject.tag == "Floor" && collCheck)
        {
            isJumping = false;
        }
    }
    private bool IsGrounded()
    {
        return Physics2D.Raycast(transform.position, -Vector2.up, GetComponent<Collider2D>().bounds.extents.y + 0.1f);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isJumping = true;
    }
}
