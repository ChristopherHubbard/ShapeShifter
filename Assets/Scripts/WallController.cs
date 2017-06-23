using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    public GameObject[] myTriggers;
    public bool isDelayed;
    public float delayTime;

    private List<SpriteRenderer> brickRenderer = new List<SpriteRenderer>();
    private Dictionary<PushButtonController, bool> myButtons = new Dictionary<PushButtonController, bool>();
    public Dictionary<PushButtonController, bool> MyButtons
    {
        get
        {
            return myButtons;
        }
    }

    private bool open;
    private Collider2D myCollider;

	// Use this for initialization
	private void Start ()
    {
        open = false;
        SetButtons();

        brickRenderer.AddRange(GetComponentsInChildren<SpriteRenderer>());
        myCollider = GetComponent<Collider2D>();
	}

    private void SetButtons()
    {
        foreach(GameObject myTrigger in myTriggers)
        {
            PushButtonController button = myTrigger.GetComponent<PushButtonController>();
            myButtons.Add(button, button.Triggered);
        }
    }

    // Update is called once per frame
    private void Update ()
    {
        if (myButtons.ContainsValue(true) && !open)
        { 
            ButtonAction(true);
        }

        else if (!myButtons.ContainsValue(true) && open)
        {
            ButtonAction(false);
        }
	}

    private void ButtonAction(bool isOpen)
    {
        open = isOpen;

        myCollider.enabled = !isOpen;
        foreach(SpriteRenderer brick in brickRenderer)
        {
            brick.enabled = !isOpen;
        }
    }
}
