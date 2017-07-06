using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts;

public class InteractionUpdate : MonoBehaviour
{
    private Button button;
    private string sceneName;

	// Use this for initialization
	private void Start ()
    {
        button = GetComponent<Button>();
        sceneName = name;

        SaveLoad.Load();

        if(UnlockedLevels.Unlocked[sceneName])
        {
            button.interactable = true;
        }
        else
        {
            button.interactable = false;
        }
	}


}
