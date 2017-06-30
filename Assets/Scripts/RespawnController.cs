using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnController : MonoBehaviour
{
    private const double worldBoundary = 250;
    private PlayerController myPlayer;
    private GameObject[] myCheckpoints;
    private AudioSource music;

	// Use this for initialization
	private void Start ()
    {
        myPlayer = GameObject.Find("Player").GetComponent<PlayerController>();
        myCheckpoints = GameObject.FindGameObjectsWithTag("Respawn");
        music = GameObject.Find("Canvas").GetComponent<PauseMenu>().Music;
    }
	
	// Update is called once per frame
	private void Update ()
    {
	    if(IsOutsideBounds())
        {
            PlayerDied();
        }
	}

    public void PlayerDied()
    {
        Debug.Log("Player Died!!");
        myPlayer.RigidB.velocity = new Vector2(0, 0);
        ResetBackgrounds();

        Time.timeScale = 1;
        music.Play();
        myPlayer.transform.position = new Vector3(myPlayer.CurrentCheckpoint.transform.position.x, myPlayer.CurrentCheckpoint.transform.position.y, 0);
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
        if(myPlayer.transform.position.y <= -worldBoundary || myPlayer.transform.position.y >= worldBoundary)
        {
            return true;
        }
        return false;
    }
}
