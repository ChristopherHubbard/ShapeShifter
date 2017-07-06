using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private UIController menuController;
    public UIController MenuController
    {
        get
        {
            return menuController;
        }
    }

    private void Awake()
    {
        menuController = new UIController(GameObject.FindGameObjectsWithTag("Pause"));
        menuController.ChangeDisplay(false);
    }

    // Use this for initialization
    private void Start ()
    {
        Time.timeScale = 1;
	}
	
	// Update is called once per frame
	private void Update ()
    {
		if(Input.GetKeyDown(KeyCode.Escape))
        {
            PauseControl();
        }
	}

    private void PauseControl()
    {
        bool display;

        if(Time.timeScale == 1)
        {
            Time.timeScale = 0;
            display = true;
        }
        else
        {
            Time.timeScale = 1;
            display = false;
        }

        menuController.ChangeDisplay(display);
    }
}
