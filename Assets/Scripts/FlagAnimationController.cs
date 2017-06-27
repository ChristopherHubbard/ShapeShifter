using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagAnimationController : MonoBehaviour
{
	// Use this for initialization
	private void Start ()
    {
        //Get the flag's animation component and reduce its speed
        Animator flagAnimator = GetComponent<Animator>();
        flagAnimator.speed = 0.75f;
	}

}
