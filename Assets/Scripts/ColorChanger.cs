using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    private Material material;

	// Use this for initialization
	void Start ()
    {
        material = GetComponent<SpriteRenderer>().material;
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collider = collision.gameObject;

        if(collider.name == "Player")
        {
            collider.GetComponent<SpriteRenderer>().material = material;
            gameObject.SetActive(false);
        }
    }
}
