using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    private Material material;

	// Use this for initialization
	private void Start ()
    {
        material = GetComponent<SpriteRenderer>().material;
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collider = collision.gameObject;

        if(collider.tag == "Player")
        {
            collider.GetComponent<SpriteRenderer>().material = material;
            gameObject.SetActive(false);
        }
    }
}
