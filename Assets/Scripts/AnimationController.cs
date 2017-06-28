using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    // Use this for initialization
    private void Start()
    {
        Animator anim = GetComponent<Animator>();
        anim.speed = 0.75f;
    }
}
