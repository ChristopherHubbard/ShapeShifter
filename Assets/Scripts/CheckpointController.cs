using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    private List<GameObject> backgrounds;
    public List<GameObject> Backgrounds
    {
        get
        {
            return backgrounds;
        }
    }

    private List<Vector3> backgroundPos = new List<Vector3>();
    public List<Vector3> BackgroundPos
    {
        get
        {
            return backgroundPos;
        }
    }

    public bool Triggered { get; set; }

    private void Start()
    {
        Triggered = false;

        backgrounds = new List<GameObject>()
        {
           GameObject.Find("Background"),
           GameObject.Find("Background2")
        };

        if (NullCheck())
        {
            foreach (GameObject background in backgrounds)
            {
                backgroundPos.Add(background.transform.position);
            }
        }
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
            myPlayer.CurrentCheckpoint = GetComponent<Collider2D>();
            Triggered = true;
            SetBackgroundInfo();

            Debug.Log("The checkpoint was hit!!");
        }
    }

    private void SetBackgroundInfo()
    {
        if (NullCheck())
        {
            for (int i = 0; i < backgrounds.Count; i++)
            {
                backgroundPos[i] = backgrounds[i].transform.position;
            }
        }
    }

    public bool NullCheck()
    {
        return backgrounds[0] != null && backgrounds[1] != null;
    }
}
