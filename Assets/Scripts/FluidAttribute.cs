using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FluidAttribute : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D playerRigidBody;
    private PlayerColorAbilities playerColorAbility;
    private RespawnController respawn;

	// Use this for initialization
	private void Start ()
    {
        player = GameObject.Find("Player");
        playerRigidBody = player.GetComponent<Rigidbody2D>();
        playerColorAbility = player.GetComponent<PlayerColorAbilities>();
        respawn = player.GetComponent<RespawnController>();
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            playerRigidBody.drag *= 100;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (LiveCheck(collision))
        {
            respawn.PlayerDied();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            playerRigidBody.drag /= 100;
        }
    }

    private bool LiveCheck(Collider2D collision)
    {
        return collision.tag == "Player" && (name == "Water" && !playerColorAbility.CanLiveWater || name == "Lava" && !playerColorAbility.CanLiveLava);
    }
}
