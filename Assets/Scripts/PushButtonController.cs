using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushButtonController : MonoBehaviour
{
    public Sprite[] availableSprites;

    private SpriteRenderer spriteRenderer;

    public bool Triggered { get; set; }

	// Use this for initialization
	private void Start ()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Triggered = false;
	}

    private void OnCollisionStay2D(Collision2D collision)
    {
        GameObject collider = collision.gameObject;

        if(collider.tag == "Player" && collider.GetComponent<ShapeAttribute>().MyShape.IsHeavy && !Triggered)
        {
            Triggered = true;
            spriteRenderer.sprite = availableSprites[1];
        }
    }
}
