using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class JumpSound : MonoBehaviour
{
    //The Player's PlayerController component
    private PlayerController myPlayer;
    //The current shape of the Player
    private Shape myShape;
    //List of all the audio sources on the Player
    private List<AudioSource> audioSources = new List<AudioSource>();
    //Audio source that contains the jump sound effect
    private AudioSource jumpSource;

	// Use this for initialization
	private void Start ()
    {
        //Get the PlayerController component
        myPlayer = GetComponent<PlayerController>();
        //Add all the audio sources to the List
        audioSources.AddRange(GetComponents<AudioSource>());
        
        //For all the audio sources
        foreach(AudioSource audioSource in audioSources)
        {
            //If the clip matches the jump clip -- then this is the jump source
            if(audioSource.clip.name == "Jump Sound")
            {
                jumpSource = audioSource;
            }
        }
	}
	
	// Update is called once per frame
	private void Update ()
    {
        //Get the current shape of the Player
        myShape = GetComponent<ShapeAttribute>().MyShape;

        //If the Player thries to jump, isn't already jumping, and isn't a heavy shape -- play the jumping sound effect
        if (Input.GetKeyDown(KeyCode.Space) && !myPlayer.IsJumping && !myShape.IsHeavy)
        {
            jumpSource.Play();
        }
	}
}
