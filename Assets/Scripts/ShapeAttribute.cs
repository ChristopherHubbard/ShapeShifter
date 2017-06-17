using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class ShapeAttribute : MonoBehaviour
{
    private PlayerController myPlayer;
    private SpriteRenderer spriteRenderer;
    private Sprite currentSprite;
    private Rigidbody2D rigidB;

    private bool sprinting;

    private Circle circle = new Circle();
    private Square square = new Square();
    private Triangle triangle = new Triangle();
    private Hexagon hexagon = new Hexagon();

    public Shape MyShape { get; set; }

    // Use this for initialization
    private void Start ()
    {
        myPlayer = GameObject.Find("Player").GetComponent<PlayerController>();
        spriteRenderer = myPlayer.GetComponent<SpriteRenderer>();
        rigidB = myPlayer.GetComponent<Rigidbody2D>();

        sprinting = false;
        currentSprite = spriteRenderer.sprite;

        FindAttributes();
        SetAttributes();
    }

    // Update is called once per frame
    private void LateUpdate ()
    {
		if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            currentSprite = spriteRenderer.sprite;
            FindAttributes();
            SetAttributes();
        }
        UseAttributes();
	}

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

    private void SetAttributes()
    {
        if(MyShape.IsHeavy)
        {
            rigidB.mass *= 5;
            myPlayer.JumpForce = 0;
        }
        else
        {
            rigidB.mass = 5;
            myPlayer.JumpForce = 100;
        }

        if(MyShape.CanHighJump)
        {
            myPlayer.JumpForce = 125; 
        }
        else if(!MyShape.IsHeavy)
        {
            myPlayer.JumpForce = 100;
        }
    }

    private void UseAttributes()
    {
        if(MyShape.CanGravChange && Input.GetKeyDown(KeyCode.Space) && !myPlayer.IsJumping)
        {
            rigidB.gravityScale *= -1;
            myPlayer.Direction *= -1;
        }
        else if(!MyShape.CanGravChange)
        {
            rigidB.gravityScale = 1;
            myPlayer.Direction = Vector2.down;
        }

        if(MyShape.CanSprint && Input.GetKeyDown(KeyCode.F) && !sprinting)
        {
            sprinting = true;
            myPlayer.MoveSpeed = 80;
        }
        else if(Input.GetKeyDown(KeyCode.F) && sprinting)
        {
            sprinting = false;
            myPlayer.MoveSpeed = 40;
        }
    }
}
