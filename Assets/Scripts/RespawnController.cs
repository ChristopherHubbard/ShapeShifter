using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnController : MonoBehaviour
{
    private const double worldBoundary = -10;
    private PlayerController myPlayer;
    private PlayerColorAbilities myAbility;

	// Use this for initialization
	void Start ()
    {
        myPlayer = GameObject.Find("Player").GetComponent<PlayerController>();
        myAbility = myPlayer.GetComponent<PlayerColorAbilities>();
    }
	
	// Update is called once per frame
	void Update ()
    {
	    if(IsOutsideBounds())
        {
            Debug.Log("Player Died!!");
            myPlayer.RigidB.velocity = new Vector2(0, 0);

            myPlayer.transform.position = myPlayer.CurrentCheckpoint.transform.position;
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
