using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class ShapeAttribute : MonoBehaviour
{
    //PlayerController component of the Player Gameobject
    private PlayerController myPlayer;
    //SpriteRenderer of the Player Gameobject
    private SpriteRenderer spriteRenderer;
    //Current sprite that the Player Gameobject is using -- used to tell which shape the Player is currently
    private Sprite currentSprite;
    //Rigidbody component of the Player -- used to change the physics surrounding the Player
    private Rigidbody2D rigidB;
    //Boolean used to tell whether the Player is sprinting or not -- only the circle shape should be able to sprint
    private bool sprinting;

    /// <summary>
    /// Private instances of each available shape for shifting (circle, square, triangle, and hexagon).
    /// These instances are used to switch the current shape when the shape shifting keycode is used.
    /// These are instantiated prior to the start or update functions to better optimize the code, by only
    /// using one instance of each shape rather than generating a new instance each time the shape is changed.
    /// All of these shape objects inherit from the Shape abstract class.
    /// </summary>
    private Circle circle = new Circle();
    private Square square = new Square();
    private Triangle triangle = new Triangle();
    private Hexagon hexagon = new Hexagon();

    //Shape object property used to store which shape the Player is currently using, and utilize the properties available to those specific shapes
    public Shape MyShape { get; set; }

    // Use this for initialization
    private void Start ()
    {
        //Find the Player and its PlayerController component
        myPlayer = GameObject.Find("Player").GetComponent<PlayerController>();
        //Get the Player's SpriteRenderer
        spriteRenderer = myPlayer.GetComponent<SpriteRenderer>();
        //Get the Player's Rigidbody
        rigidB = myPlayer.GetComponent<Rigidbody2D>();

        //The Player is never initially sprinting
        sprinting = false;
        //Set the current sprite
        currentSprite = spriteRenderer.sprite;

        //Find and set the initial attributes of the Player's shape
        FindAttributes();
        SetAttributes();
    }

    // Update is called once per frame
    private void LateUpdate ()
    {
        //If the Player attempts to shift shapes
		if(Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            //Update the current sprite -- find and set the attributes of the shape
            currentSprite = spriteRenderer.sprite;
            FindAttributes();
            SetAttributes();
        }
        //Use the attributes of the Player's shape
        UseAttributes();
	}

    /// <summary>
    /// Find the shape based attributes of the Player based on the name of the current sprite
    /// that is being used by the SpriteRenderer. This method determines this by using a switch
    /// with a case for each of the four available shapes, and then seting the attributes by updating
    /// the MyShape property to the instance of the shape that the current sprite indicates.
    /// </summary>
    private void FindAttributes()
    {
        switch(currentSprite.name)
        {
            case "Square":
                MyShape = square;
                break;
            case "Circle":
                MyShape = circle;
                break;
            case "Triangle":
                MyShape = triangle;
                break;
            case "Hexagon":
                MyShape = hexagon;
                break;
        }

    }

    /// <summary>
    /// Method used to set the attributes of the Player's shape. These attributes are only attributes that are not
    /// affected by input from the user's input from the keyboard, they are always present when the Player is using that
    /// shape.
    /// </summary>
    private void SetAttributes()
    {
        //If the Shape is a heavy shape -- increase the Player mass and the Player can no longer jump
        if(MyShape.IsHeavy)
        {
            rigidB.mass *= 5;
            myPlayer.JumpForce = 0;
        }
        //If the Shape isn't heavy -- use default Player mass and JumpForce
        else
        {
            rigidB.mass = 5;
            myPlayer.JumpForce = 100;
        }

        //If the Shape can do a high jump -- increase the JumpForce
        if(MyShape.CanHighJump)
        {
            myPlayer.JumpForce = 125; 
        }
        //If the Shape can't do a high jump and isn't heavy -- use the default Player JumpForce
        else if(!MyShape.IsHeavy)
        {
            myPlayer.JumpForce = 100;
        }
    }

    /// <summary>
    /// Method used to use the attributes available to the Player's current shape. These attributes are primarily attributes
    /// that are changed based on the user's input and the current shape. This means that some of these attributes are not apparent
    /// unless the user presses the correct input.
    /// </summary>
    private void UseAttributes()
    {
        //If the shape can change gravity, the special ability key is pressed, and the player isn't jumping
        if(MyShape.CanGravChange && Input.GetKeyDown(KeyCode.F) && !myPlayer.IsJumping)
        {
            //Reverse the gravity, the direction vector (for telling if the player is grounded), and the jumpForce
            rigidB.gravityScale *= -1;
            myPlayer.Direction *= -1;
            myPlayer.JumpForce *= -1;
        }
        //If the shape can't change the gravity -- set the Player's gravity, direction vector, and JumpForce to their appropriate values
        else if(!MyShape.CanGravChange)
        {
            rigidB.gravityScale = 1;
            myPlayer.Direction = Vector2.down;
            
            if(MyShape.CanHighJump)
            {
                myPlayer.JumpForce = 125;
            }
            else if(!MyShape.IsHeavy)
            {
                myPlayer.JumpForce = 100;
            }
            else
            {
                myPlayer.JumpForce = 0;
            }
        }

        //If the shape can sprint, the special ability key is pressed, and the player isn't already sprinting -- set sprinting to true and increase the MoveSpeed
        if(MyShape.CanSprint && Input.GetKeyDown(KeyCode.F) && !sprinting)
        {
            sprinting = true;
            myPlayer.MoveSpeed *= 2;
        }
        //If the shape can't sprint or the special ability key is pressed and the player is sprinting -- set sprinting to false and decrease the MoveSpeed to the default value
        else if(!MyShape.CanSprint || Input.GetKeyDown(KeyCode.F) && sprinting)
        {
            sprinting = false;
            myPlayer.MoveSpeed = 40;
        }
    }
}
