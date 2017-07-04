using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private List<GameObject> pauseMenuObjects = new List<GameObject>();
    private AudioSource music;
    public AudioSource Music
    {
        get
        {
            return music;
        }
    }

	// Use this for initialization
	private void Start ()
    {
        List<AudioSource> audioSources = new List<AudioSource>();
        Time.timeScale = 1;
        pauseMenuObjects.AddRange(GameObject.FindGameObjectsWithTag("Pause"));

        audioSources.AddRange(GameObject.Find("Player").GetComponents<AudioSource>());
        foreach(AudioSource audio in audioSources)
        {
            if(audio.loop)
            {
                music = audio;
            }
        }

        ShowMenu(false);
	}
	
	// Update is called once per frame
	private void Update ()
    {
		if(Input.GetKeyDown(KeyCode.Escape))
        {
            PauseControl();
        }
	}

    private void PauseControl()
    {
        if(Time.timeScale == 1)
        {
            Time.timeScale = 0;
            ShowMenu(true);
        }
        else
        {
            Time.timeScale = 1;
            ShowMenu(false);
        }
    }

    private void ShowMenu(bool value)
    {
        StopMusic(value);

        foreach(GameObject pause in pauseMenuObjects)
        {
            pause.SetActive(value);
        }
    }

    private void StopMusic(bool value)
    {
        if(value)
        {
            music.Pause();
        }
        else
        {
            music.UnPause();
        }
        
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
