using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public RuntimeAnimatorController hitController;

    private Animator animator;
    private CheckpointController myCheckpoint;

    // Use this for initialization
    private void Start()
    {
        animator = GetComponent<Animator>();
        myCheckpoint = GetComponent<CheckpointController>();
        animator.speed = 0.75f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            animator.runtimeAnimatorController = hitController;
        }
    }
}
