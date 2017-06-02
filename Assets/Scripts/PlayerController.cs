using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Public variables to manipulate in Unity
    public float speed;
    public int jump;

    //Private variables for movement
    private Rigidbody2D rigidB;
    public float distToGround;
    public bool isJumping;
    
    //Called when the object is initialized
    private void Start()
    {
        rigidB = GetComponent<Rigidbody2D>();
        distToGround = GetComponent<Collider2D>().bounds.extents.y;
    }

    //Called in a fixed interval -- best used when dealing with Physics
    private void Update()
    {
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            /*
            //Update isJumping
            isJumping = IsJumping();
            */
            //rigidB.velocity = new Vector2(rigidB.velocity.x, jumpVelocity);
            rigidB.AddForce(new Vector2(0, jump * speed),ForceMode2D.Impulse);
        }

    }

    //Called in a fixed interval -- best used when dealing with Physics
    private void FixedUpdate()
    {
        rigidB.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rigidB.velocity.y);
    }

    
    /// <summary>
    /// On collision with a 2D object
    /// Primarily used to check for collision with a platform
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionStay2D(Collision2D collision)
    {
        isJumping = IsJumping();
    }
    

    private bool IsJumping()
    {
        float y = transform.position.y - distToGround;
        RaycastHit2D[] rays = Physics2D.RaycastAll(new Vector2(transform.position.x, y), Vector2.down, distToGround + 0.1f);
        //Debug.Log(r.collider.name);
        foreach(RaycastHit2D ray in rays)
        {
            Debug.Log(ray.collider.name);
            if (ray.collider != null && ray.collider.tag != "Player")
            {
                return false;
            }
        }
        return true;
    }

    
    private void OnCollisionExit2D(Collision2D collision)
    {
        isJumping = IsJumping();
    }
    
    
}
