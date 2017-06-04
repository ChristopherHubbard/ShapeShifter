using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    private bool Triggered { get; set; }

    private void Start()
    {
        Triggered = false;
    }
    /// <summary>
    /// Called when the Checkpoints collide with the Player.
    /// Used to set the Player's CurrentCheckpoint property
    /// to the Collider2D of the Checkpoint it is hitting.
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!Triggered && collision.tag == "Player")
        {
            PlayerController myPlayer = GameObject.Find("Player").GetComponent<PlayerController>();
            myPlayer.CurrentCheckpoint = this.GetComponent<Collider2D>();
            Triggered = true;

            Debug.Log("The checkpoint was hit!!");
        }
    }
}
