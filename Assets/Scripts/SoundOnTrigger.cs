using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOnTrigger : MonoBehaviour
{
    public bool isEnter;
    public bool isExit;
    public bool playOnceOnly;

    private AudioSource sound;
    private bool triggered;

	// Use this for initialization
	private void Start ()
    {
        sound = GetComponent<AudioSource>();
        triggered = false;
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (ConditionCheck(isEnter))
        {
            Play(collision);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (ConditionCheck(isExit))
        {
            Play(collision);
        }
    }

    private bool ConditionCheck(bool check)
    {
        return check && (!playOnceOnly || playOnceOnly && !triggered); 
    }

    private void Play(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            sound.Play();
            triggered = true;
        }
    }
}
