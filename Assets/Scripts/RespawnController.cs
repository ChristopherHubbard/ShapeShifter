using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnController : MonoBehaviour
{
    PlayerController myPlayer;
    public float worldBoundary;

	// Use this for initialization
	void Start ()
    {
        myPlayer = GameObject.Find("Player").GetComponent<PlayerController>();
    }
	
	// Update is called once per frame
	void Update ()
    {
	    if(myPlayer.transform.position.y <= worldBoundary)
        {
            Debug.Log("Player Died!!");
            myPlayer.RigidB.velocity = new Vector2(0, 0);

            myPlayer.transform.position = myPlayer.CurrentCheckpoint.transform.position;
        }
	}
}
