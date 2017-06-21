using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeController : MonoBehaviour
{
    //Player GameObject for positioning
    public GameObject player;
    //SpriteRenderer of the eye
    private SpriteRenderer eyeSprite;

    //Vector3 to offset from the position of the player
    private Vector3 offset;
    //Adjusted offsets for flipping
    private Vector3 offsetNotFlipped;
    private Vector3 offsetFlipped;

    //Quaternion for the rotation of the eyes about themselves
    private Quaternion rotation;

    private Rigidbody2D playerRigidBody;

    /// <summary>
    /// Start is called at initialization and is used
    /// to set the private fields on the eyes
    /// and initialize them
    /// </summary>
    private void Start()
    {
        //Get the sprite renderer
        eyeSprite = GetComponent<SpriteRenderer>();

        //Get the adjustment value for this eye and set the offsets
        float adjustment = AdjustForEye(gameObject.name);
        offsetNotFlipped = transform.position - player.transform.position;
        offsetFlipped = transform.position - player.transform.position - new Vector3(adjustment, 0, 0);

        //Initially the eyes are not flipped
        offset = offsetNotFlipped;
        //Set the initial rotation
        rotation = transform.rotation;

        playerRigidBody = player.GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Update is called once per frame and is primarily
    /// used to flip the eyes or not flip the eyes depending
    /// on the direction of motion.
    /// </summary>
    private void Update()
    {
        //If moving to the left -- flip the eyes
        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            eyeSprite.flipX = true;
            offset = offsetFlipped;
        }
        //If moving to the right -- don't flip the eyes
        else if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            eyeSprite.flipX = false;
            offset = offsetNotFlipped;
        }
    }

    /// <summary>
    /// LateUpdate is called once per frame at the end of
    /// the frame. Used on the eye to maintain its position 
    /// on the player's body and prevent rotation of the eyes.
    /// </summary>
    private void LateUpdate()
    {
        //Keep the eye at the player plus the eye's offset
        transform.position = player.transform.position + offset;
        //Prevent the rotation of the eye from changing.
        transform.rotation = rotation;
    }

    /// <summary>
    /// Method returns a float of the amount
    /// that each eye needs to be adjusted on
    /// the player in order to appear as if
    /// the player has turned around.
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    private float AdjustForEye(string name)
    {
        float adjust = 0;
        float radius = player.GetComponent<CircleCollider2D>().radius;

        //Eye and Eye2 have different offsets
        switch(name)
        {
            case "Eye":
                adjust = radius - 0.2f;
                break;
            case "Eye2":
                adjust = 2 * radius;
                break;
        }
        //Return the adjustment
        return adjust;
    }

}
