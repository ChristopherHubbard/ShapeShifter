using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOnTrigger : MonoBehaviour
{
    public bool isEnter;
    public bool isExit;

    private AudioSource sound;

	// Use this for initialization
	private void Start ()
    {
        sound = GetComponent<AudioSource>();
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isEnter)
        {
            Play(collision);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (isExit)
        {
            Play(collision);
        }
    }

    private void Play(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            sound.Play();
        }
    }
}
