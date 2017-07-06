using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagAnimationController : MonoBehaviour
{
    public RuntimeAnimatorController hitController;

    private Animator animator;

    // Use this for initialization
    private void Start()
    {
        animator = GetComponent<Animator>();
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
