using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    public GameObject[] myTriggers;

    private Dictionary<PushButtonController, bool> myButtons = new Dictionary<PushButtonController, bool>();
    public Dictionary<PushButtonController, bool> MyButtons
    {
        get
        {
            return myButtons;
        }
    }

    private bool open;

    private Vector3 originalLocation;
    private Vector3 openLocation;

	// Use this for initialization
	private void Start ()
    {
        open = false;
        SetButtons();
        originalLocation = transform.position;
        openLocation = transform.position + new Vector3(0, 5f, 0);
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
            SetLocation(true, openLocation);
        }

        else if (!myButtons.ContainsValue(true) && open)
        {
            SetLocation(false, originalLocation);
        }
	}

    private void SetLocation(bool isOpen, Vector3 setLocation)
    {
        open = isOpen;
        transform.position = setLocation;
    }
}
