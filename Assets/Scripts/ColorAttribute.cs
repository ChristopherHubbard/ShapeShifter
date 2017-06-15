using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorAttribute : MonoBehaviour
{
    private GameObject myPlayer;
    private PlayerColorAbilities myColorAbility;
    private SpriteRenderer mySprite;
    private Material myMaterial;

	// Use this for initialization
	private void Start ()
    {
        myPlayer = GameObject.Find("Player");
        myColorAbility = myPlayer.GetComponent<PlayerColorAbilities>();
        mySprite = GameObject.Find("Player").GetComponent<SpriteRenderer>();
        myMaterial = mySprite.material;
		
	}

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player" && myMaterial != mySprite.material)
        {
            myMaterial = mySprite.material;
            ChangeColorAttributes();
        }
    }

    private void ChangeColorAttributes()
    {
        if(myMaterial.name == "Blue")
        {
            myColorAbility.CanLiveWater = true;
        }
        else
        {
            myColorAbility.CanLiveWater = false;
        }

        if(myMaterial.name == "Red")
        {
            myColorAbility.CanLiveFire = true;
        }
        else
        {
            myColorAbility.CanLiveFire = false;
        }
    }
}
