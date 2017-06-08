using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangerRotater : MonoBehaviour
{
    private float angle = 0;
    private const float increase = 2;
    private SpriteRenderer sprite;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate ()
    {
        AdjustAngle();
        FlipSprite();
        transform.Rotate(Vector3.up, increase);

	}

    private void AdjustAngle()
    {
        angle += increase;
        if(angle == 180)
        {
            angle = -180;
        }
    }

    private void FlipSprite()
    {
        if(angle > 90 || (angle > -180 && angle < -90))
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }
    }
}
