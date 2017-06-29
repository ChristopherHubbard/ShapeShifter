using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorAttributeChanger : MonoBehaviour
{
    private GameObject myPlayer;
    private PlayerColorAbilities myColorAbility;
    private SpriteRenderer mySprite;

	// Use this for initialization
	private void Start ()
    {
        myPlayer = GameObject.Find("Player");
        myColorAbility = myPlayer.GetComponent<PlayerColorAbilities>();
        mySprite = myPlayer.GetComponent<SpriteRenderer>();
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            ChangeColorAttributes();
        }
    }

    private void ChangeColorAttributes()
    {
        if(mySprite.material.name == "Blue" + PlayerColorAbilities.GetAddInstance() + PlayerColorAbilities.GetAddInstance())
        {
            myColorAbility.CanLiveWater = true;
        }
        else
        {
            myColorAbility.CanLiveWater = false;
        }

        if(mySprite.material.name == "Red" + PlayerColorAbilities.GetAddInstance() + PlayerColorAbilities.GetAddInstance())
        {
            myColorAbility.CanLiveLava = true;
        }
        else
        {
            myColorAbility.CanLiveLava = false;
        }
    }
}
