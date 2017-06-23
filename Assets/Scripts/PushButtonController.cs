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
    public bool isOscillator;

    private List<WallController> wallController = new List<WallController>();
    private SpriteRenderer spriteRenderer;
    private bool oscillating;

    public bool Triggered { get; set; }

	// Use this for initialization
	private void Start ()
    {
        SetWallControllers();

        spriteRenderer = GetComponent<SpriteRenderer>();
        Triggered = false;
        oscillating = false;
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
            UpdateTriggers(true);
            spriteRenderer.sprite = availableSprites[1];
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {

        if(Triggered && isTimed)
        {
            StartCoroutine(ResetButtonTimed());
        }

        if(Triggered && isOscillator && !oscillating)
        {
            StartCoroutine(OscillateButton());
        }
    }

    private IEnumerator ResetButtonTimed()
    {
        yield return new WaitForSecondsRealtime(duration);

        EndCoroutines();
        spriteRenderer.sprite = availableSprites[0];
    }

    private IEnumerator OscillateButton()
    {
        oscillating = true;

        while (oscillating)
        {
            yield return new WaitForSecondsRealtime(0.5f);
            UpdateTriggers(!Triggered);
        }
    }

    private IEnumerator Delay(WallController wall, bool value)
    {
        yield return new WaitForSecondsRealtime(wall.delayTime);
        wall.MyButtons[this] = value;
    }

    private void UpdateTriggers(bool value)
    {
        Triggered = value;

        foreach(WallController wall in wallController)
        {
            if(wall.isDelayed)
            {
                StartCoroutine(Delay(wall, value));
            }
            else
            {
                wall.MyButtons[this] = value;
            }
            //wall.MyButtons[this] = value;
        }
    }

    private void EndCoroutines()
    {
        StopAllCoroutines();
        oscillating = false;
        UpdateTriggers(false);
    }
}
