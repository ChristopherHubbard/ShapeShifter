using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Public variables to manipulate in Unity
    public float speed;
    public int jumpHeight;

    //Private variables for movement
    private Rigidbody2D rigidB;
    private bool isJumping = false;
    
    //Called when the object is initialized
    private void Start()
    {
        rigidB = GetComponent<Rigidbody2D>();
    }

    //Called in a fixed interval -- best used when dealing with Physics
    private void FixedUpdate()
    {
        //Get the input for the horizontal movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        //Default is not jumping
        float jump = 0;
        //If the space bar is pushed and the Shape Shifter isn't already jumping
        if (Input.GetKeyDown("space") && !isJumping)
        {
            //Set isJumping to true and set jump to the jumpHeight 
            isJumping = true;
            jump = jumpHeight;
        }
        //Create a new Vector2 with the given force directions -- add the force to the rigid body
        Vector2 movement = new Vector2(moveHorizontal, jump);
        rigidB.AddForce(movement * speed);

    }

    /// <summary>
    /// On collision with a 2D object
    /// Primarily used to check for collision with a platform
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionStay2D(Collision2D collision)
    {
        //Collision check to see if the player is on the top of the collision object
        bool collCheck = collision.gameObject.transform.position.y <= transform.position.y;
        //If the player collided with the floor
        if(collision.gameObject.tag == "Floor" && isJumping && collCheck)
        {
            isJumping = false;
        }
    }
}
