using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushButtonController : MonoBehaviour
{
    private const float duration = 5;

    public GameObject[] controlling;
    public Sprite[] availableSprites;
    public bool isTimed;

    private List<WallController> wallController = new List<WallController>();
    private SpriteRenderer spriteRenderer;

    public bool Triggered { get; set; }

	// Use this for initialization
	private void Start ()
    {
        SetWallControllers();

        spriteRenderer = GetComponent<SpriteRenderer>();
        Triggered = false;
	}

    private void SetWallControllers()
    {
        foreach(GameObject control in controlling)
        {
            wallController.Add(control.GetComponent<WallController>());
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        GameObject collider = collision.gameObject;

        if(collider.tag == "Player" && collider.GetComponent<ShapeAttribute>().MyShape.IsHeavy && !Triggered)
        {
            Triggered = true;
            UpdateTriggers(Triggered);
            spriteRenderer.sprite = availableSprites[1];
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(Triggered && isTimed)
        {
            StartCoroutine(ResetButtonTimed());
        }
    }

    private IEnumerator ResetButtonTimed()
    {
        yield return new WaitForSecondsRealtime(duration);

        Triggered = false;
        UpdateTriggers(Triggered);
        spriteRenderer.sprite = availableSprites[0];
    }

    private void UpdateTriggers(bool value)
    {
        foreach(WallController wall in wallController)
        {
            wall.MyButtons[this] = value;
        }
    }
}
