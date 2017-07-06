using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    private UIController endUI;
    private AudioSource endMusic;

    private void Start()
    {
        endMusic = GetComponent<AudioSource>();
        endUI = new UIController(GameObject.FindGameObjectsWithTag("Finish"));
        endUI.ChangeDisplay(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("The level is over!!");
            LevelComplete();
        }
    }

    private void LevelComplete()
    {
        Time.timeScale = 0;
        UnlockNextLevel();
        endUI.ChangeDisplay(true);
        endMusic.Play();
    }

    private void UnlockNextLevel()
    {
        int levelNumber;
        bool working = Int32.TryParse(SceneManager.GetActiveScene().name.Split('-')[1], out levelNumber);

        if(!working)
        {
            throw new FormatException();
        }
        levelNumber++;

        UnlockedLevels.Unlocked["Level 1-" + levelNumber] = true;

        SaveLoad.Save();
    }
}
