using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeShifter : MonoBehaviour
{
    public Sprite[] spriteArray;

    private PlayerController myPlayer;

    private int CurrentIndex { get; set; }
    private Sprite CurrentSprite { get; set; }

	// Use this for initialization
	private void Start ()
    {
        myPlayer = GameObject.Find("Player").GetComponent<PlayerController>();
        CurrentSprite = myPlayer.GetComponent<SpriteRenderer>().sprite;
        CurrentIndex = Array.IndexOf(spriteArray, CurrentSprite);
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
            myPlayer.GetComponent<SpriteRenderer>().sprite = CurrentSprite;
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
}
