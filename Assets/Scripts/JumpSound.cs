using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class JumpSound : MonoBehaviour
{
    private PlayerController myPlayer;
    private Shape myShape;

    private List<AudioSource> audioSources = new List<AudioSource>();
    private AudioSource jumpSource;

	// Use this for initialization
	private void Start ()
    {
        myPlayer = GetComponent<PlayerController>();

        audioSources.AddRange(GetComponents<AudioSource>());
        
        foreach(AudioSource audioSource in audioSources)
        {
            if(audioSource.clip.name == "Jump Sound")
            {
                jumpSource = audioSource;
            }
        }
	}
	
	// Update is called once per frame
	private void Update ()
    {
        myShape = GetComponent<ShapeAttribute>().MyShape;

        if (Input.GetKeyDown(KeyCode.Space) && !myPlayer.IsJumping && !myShape.IsHeavy)
        {
            jumpSource.Play();
        }
	}
}
