using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnController : MonoBehaviour
{
    private const double worldBoundary = -100;
    private PlayerController myPlayer;
    //private PlayerColorAbilities myAbility;
    private GameObject[] myCheckpoints;

	// Use this for initialization
	private void Start ()
    {
        myPlayer = GameObject.Find("Player").GetComponent<PlayerController>();
        //myAbility = myPlayer.GetComponent<PlayerColorAbilities>();
        myCheckpoints = GameObject.FindGameObjectsWithTag("Respawn");
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
        foreach (GameObject myCheckpoint in myCheckpoints)
        {
            CheckpointController checkpoint = myCheckpoint.GetComponent<CheckpointController>();
            Collider2D checkpointCollider = myCheckpoint.GetComponent<Collider2D>();

            if (checkpointCollider == myPlayer.CurrentCheckpoint)
            {
                if (checkpoint.NullCheck())
                {
                    for (int i = 0; i < checkpoint.Backgrounds.Count; i++)
                    {
                        checkpoint.Backgrounds[i].transform.position = checkpoint.BackgroundPos[i];
                    }

                }
            }
        }
    }

    private bool IsOutsideBounds()
    {
        //If the player is outside the bounds of the world
        if(myPlayer.transform.position.y <= worldBoundary || myPlayer.transform.position.y >= 250)
        {
            return true;
        }
        return false;
    }
}
