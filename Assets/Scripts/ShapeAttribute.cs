﻿using System;
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

    private Shape myShape;

    private Circle circle = new Circle();
    private Square square = new Square();
    private Triangle triangle = new Triangle();
    private Hexagon hexagon = new Hexagon();

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
                myShape = square;
                break;
            case "Circle":
                myShape = circle;
                break;
            case "Triangle":
                myShape = triangle;
                break;
            case "Hexagon":
                myShape = hexagon;
                break;
        }

    }

    private void SetAttributes()
    {
        if(myShape.IsHeavy)
        {
            rigidB.mass *= 5;
            myPlayer.JumpForce = 0;
        }
        else
        {
            rigidB.mass = 5;
            myPlayer.JumpForce = 100;
        }

        if(myShape.CanHighJump)
        {
            myPlayer.JumpForce = 150; 
        }
        else if(!myShape.IsHeavy)
        {
            myPlayer.JumpForce = 100;
        }
    }

    private void UseAttributes()
    {
        if(myShape.CanGravChange && Input.GetKeyDown(KeyCode.Space))
        {
            rigidB.gravityScale *= -1;
        }

        if(myShape.CanSprint && Input.GetKeyDown(KeyCode.F) && !sprinting)
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
