using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColorAbilities : MonoBehaviour
{
    private Material myMaterial;

    public bool CanLiveWater { get; set; }
    public bool CanLiveLava { get; set; }

    // Use this for initialization
    private void Start ()
    {
        myMaterial = GameObject.Find("Player").GetComponent<SpriteRenderer>().material;

        SetAbilities();
	}

    private void SetAbilities()
    {
        if (myMaterial.name != "Blue" + GetAddInstance())
        {
            CanLiveWater = false;
        }
        else
        {
            CanLiveWater = true;
        }

        if (myMaterial.name != "Red" + GetAddInstance())
        {
            CanLiveLava = false;
        }
        else
        {
            CanLiveLava = true;
        }
    }

    public static string GetAddInstance()
    {
        return " (Instance)";
    }

}
