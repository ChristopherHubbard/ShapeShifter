using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColorAbilities : MonoBehaviour
{
    private Material myMaterial;

    public bool CanLiveWater { get; set; }
    public bool CanLiveFire { get; set; }


	// Use this for initialization
	void Start ()
    {
        myMaterial = GameObject.Find("Player").GetComponent<SpriteRenderer>().material;

        if(myMaterial.name != "Blue")
        {
            CanLiveWater = false;
        }
        else
        {
            CanLiveWater = true;
        }

        if(myMaterial.name != "Red")
        {
            CanLiveFire = false;
        }
        else
        {
            CanLiveFire = true;
        }

	}

}
