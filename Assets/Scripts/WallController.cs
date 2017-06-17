using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    public GameObject myTrigger;

    private PushButtonController myButton;
    private bool open;

    private const float interval = 0.001f;
    private Vector3 desiredLocation;

	// Use this for initialization
	private void Start ()
    {
        open = false;
        myButton = myTrigger.GetComponent<PushButtonController>();
        desiredLocation = new Vector3(transform.position.x, transform.position.y + 5f, transform.position.z);
	}
	
	// Update is called once per frame
	private void Update ()
    {
        if(myButton.Triggered && !open)
        {
            open = true;
            transform.position = desiredLocation;
        }
	}
}
