using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    private Material material;

	// Use this for initialization
	private void Start ()
    {
        //Get the material of this Color Changer
        material = GetComponent<SpriteRenderer>().material;
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If the Color Changer is colliding with the Player Gameobject -- set the Player's material to the same as the Color Changer and deactivate the Color Changer
        if(collision.tag == "Player")
        {
            collision.GetComponent<SpriteRenderer>().material = material;
            //GetComponent<SpriteRenderer>().enabled = false;
            // ^^^ would need method to enable on respawn ^^^

            //gameObject.SetActive(false);
        }
    }
}
