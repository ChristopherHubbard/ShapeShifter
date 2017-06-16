using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnController : MonoBehaviour
{
    private const double worldBoundary = -10;
    private PlayerController myPlayer;
    private PlayerColorAbilities myAbility;
    private CheckpointController myCheckpoint;

	// Use this for initialization
	private void Start ()
    {
        myPlayer = GameObject.Find("Player").GetComponent<PlayerController>();
        myAbility = myPlayer.GetComponent<PlayerColorAbilities>();
        myCheckpoint = GameObject.FindGameObjectWithTag("Respawn").GetComponent<CheckpointController>();
    }
	
	// Update is called once per frame
	private void Update ()
    {
	    if(IsOutsideBounds())
        {
            Debug.Log("Player Died!!");
            myPlayer.RigidB.velocity = new Vector2(0, 0);
            ResetBackgrounds();

            myPlayer.transform.position = myPlayer.CurrentCheckpoint.transform.position;
        }
	}

    private void ResetBackgrounds()
    {
        for(int i = 0; i < myCheckpoint.Backgrounds.Count; i++)
        {
            myCheckpoint.Backgrounds[i].transform.position = myCheckpoint.BackgroundPos[i];
        }
    }

    private bool IsOutsideBounds()
    {
        //If the player is outside the bounds of the world
        if(myPlayer.transform.position.y <= worldBoundary)
        {
            return true;
        }
        return false;
    }
}
