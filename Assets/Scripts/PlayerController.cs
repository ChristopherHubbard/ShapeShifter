using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Constant variables -- may want to encapsulate later
    private const float jumpForce = 100;
    private const float moveSpeed = 40;

    //Private variables for movement and measurment
    private float distToGround;

    public Rigidbody2D RigidB { get; set; }

    /// <summary>
    /// CurrentCheckpoint collider2D property
    /// Used to hold a reference to the last Checkpoint object that the
    /// Player has hit. Currently initialized to the player's starting
    /// location at the beginning of the game.
    /// </summary>
    public Collider2D CurrentCheckpoint { get; set; }

    /// <summary>
    /// Property to tell if the Player is jumping
    /// Uses RaycastAll to detect all collider objects
    /// below the Player and then determines whether jumping is
    /// allowed.
    /// </summary>
    public bool IsJumping
    {
        get
        {
            //Find the bottom of the Player
            float ypos = transform.position.y - distToGround;
            Vector2 groundCheck = new Vector2(transform.position.x, ypos);

            //Ray for debugging
            Ray debugRay = new Ray(new Vector3(groundCheck.x, groundCheck.y, 0), Vector3.down);

            //RaycastAll to find all colliders below the Player (sometimes including the player) and create an array
            RaycastHit2D[] rays = Physics2D.RaycastAll(groundCheck, Vector2.down, distToGround + 0.2f);
            //For all of the rays that were collided with
            foreach (RaycastHit2D ray in rays)
            {
                //Log each ray's collider for debugging
                Debug.Log(ray.collider.name);

                //If the ray collided with something and it wasn't the Player -- not jumping
                if (ray.collider != null && ray.collider.tag != "Player" && ray.collider.tag != "Respawn")
                {
                    return false;
                }
            }
            //The Player must be jumping
            return true;
        }
    }
    
    /// <summary>
    /// Called when the player object is initialized.
    /// Currently used to get the Rigidbody2D component
    /// and the disToGround of the Player character.
    /// Also used to set the Player's initial checkpoint at
    /// the beginning of the level.
    /// </summary>
    private void Start()
    {
        RigidB = GetComponent<Rigidbody2D>();
        distToGround = GetComponent<Collider2D>().bounds.extents.y;
    }

    /// <summary>
    /// Called in a once per frame.
    /// Used to update the Physics for the jumping
    /// of the player character by getting the IsJumping
    /// property.
    /// </summary>
    private void Update()
    {

        //If the player is trying to jump and isn't already jumping
        if (Input.GetKeyDown(KeyCode.Space) && !IsJumping)
        {
            //Zero out the Player's velocity in y in order to allow for more consistent jumping
            RigidB.velocity = new Vector2(RigidB.velocity.x, 0);
            //Add an instantaneous force in the y direction of magnitude jumpForce
            RigidB.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }

    /// <summary>
    /// Called at a fixed interval, regardless of framerate.
    /// Used to update the horizontal movement physics of the 
    /// player character.
    /// </summary>
    private void FixedUpdate()
    {
        //Zero out the Player's velocity in x in order to allow for more precise movements
        RigidB.velocity = new Vector2(0, RigidB.velocity.y);
        //Add an instantaneous (ForceMode2D.Impulse) to the Player for horizontal movements
        RigidB.AddForce(new Vector2(Input.GetAxis("Horizontal") * moveSpeed, 0), ForceMode2D.Impulse);
    }

}
