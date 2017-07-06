using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController: MonoBehaviour
{
    public List<GameObject> UIObjects { get; set; }
    public AudioSource Music { get; set; }

    private UIController()
    {

    }

    public UIController(GameObject[] UIObject)
    {
        UIObjects = new List<GameObject>();
        UIObjects.AddRange(UIObject);
        FindMusic();
        ChangeDisplay(false);
    }

    private void FindMusic()
    {
        List<AudioSource> audioSources = new List<AudioSource>();
        audioSources.AddRange(GameObject.Find("Player").GetComponents<AudioSource>());
        foreach (AudioSource audio in audioSources)
        {
            if (audio.loop)
            {
                Music = audio;
            }
        }
    }

    public void ChangeDisplay(bool display)
    {
        StopMusic(display);

        foreach (GameObject UIObject in UIObjects)
        {
            UIObject.SetActive(display);
        }
    }

    private void StopMusic(bool play)
    {
        if (play)
        {
            Music.Pause();
        }
        else
        {
            Music.UnPause();
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
