using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Public variables to manipulate in Unity
    private float jumpForce = 100;
    private float moveSpeed = 40;

    //Private variables for movement and measurment
    private Rigidbody2D rigidB;
    private float distToGround;

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
            float y = transform.position.y - distToGround;
            RaycastHit2D[] rays = Physics2D.RaycastAll(new Vector2(transform.position.x, y), Vector2.down, distToGround + 0.1f);
            foreach (RaycastHit2D ray in rays)
            {
                Debug.Log(ray.collider.name);
                if (ray.collider != null && ray.collider.tag != "Player")
                {
                    return false;
                }
            }
            return true;
        }
    }
    
    //Called when the object is initialized
    private void Start()
    {
        rigidB = GetComponent<Rigidbody2D>();
        distToGround = GetComponent<Collider2D>().bounds.extents.y;
    }
    //Called in a fixed interval -- best used when dealing with Physics
    private void FixedUpdate()
    {
        rigidB.velocity = new Vector2(0, rigidB.velocity.y);
       
        rigidB.AddForce(new Vector2(Input.GetAxis("Horizontal") * moveSpeed, 0), ForceMode2D.Impulse);

        if (Input.GetButtonDown("Jump") && !IsJumping)
        {
            rigidB.velocity = new Vector2(rigidB.velocity.x, 0);
            rigidB.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }
    
}
