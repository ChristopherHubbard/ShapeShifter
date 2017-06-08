using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeShifter : MonoBehaviour
{
    public Sprite[] spriteArray;

    private PlayerController myPlayer;

    private int CurrentIndex { get; set; }
    private SpriteRenderer spriteRenderer;
    private Sprite CurrentSprite { get; set; }

	// Use this for initialization
	private void Start ()
    {
        myPlayer = GameObject.Find("Player").GetComponent<PlayerController>();
        spriteRenderer = myPlayer.GetComponent<SpriteRenderer>();

        CurrentSprite = spriteRenderer.sprite;
        CurrentIndex = Array.IndexOf(spriteArray, CurrentSprite);

        AdjustShape();
        ChangeCollider();
    }
	
	// Update is called once per frame
	private void Update ()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            CurrentIndex++;
            if(CurrentIndex > spriteArray.Length - 1)
            {
                CurrentIndex = 0;
            }

            CurrentSprite = spriteArray[CurrentIndex];
            spriteRenderer.sprite = CurrentSprite;
            AdjustShape();
            ChangeCollider();
        }
		
	}

    private void ChangeCollider()
    {
        CircleCollider2D collider = myPlayer.GetComponent<Collider2D>() as CircleCollider2D;

        if (CurrentSprite.name == "Triangle")
        {
            collider.radius = 0.3f;
        }
        else
        {
            collider.radius = 0.5f;
        }
    }

    private void AdjustShape()
    {
        if(CurrentSprite.name == "Square")
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }
}
