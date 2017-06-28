using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterAttribute : MonoBehaviour
{
    private Rigidbody2D playerRigidBody;

	// Use this for initialization
	private void Start ()
    {
        playerRigidBody = GameObject.Find("Player").GetComponent<Rigidbody2D>();
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            playerRigidBody.drag *= 100;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            playerRigidBody.drag /= 100;
        }
    }
}
