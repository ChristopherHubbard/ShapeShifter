using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public GameObject otherBackground;

    private Rigidbody2D playerRigidBody;
    private Vector3 moveDistance;

	// Use this for initialization
	void Start ()
    {
        playerRigidBody = GameObject.Find("Player").GetComponent<Rigidbody2D>();

        moveDistance = new Vector3(GetComponent<SpriteRenderer>().bounds.extents.x * 2, 0, 0);
        Debug.Log(moveDistance);
	}

    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(playerRigidBody.velocity.x > 0)
            {
                otherBackground.transform.position = transform.position + moveDistance;
            }
            else if(playerRigidBody.velocity.x < 0)
            {
                otherBackground.transform.position = transform.position - moveDistance;
            }
        }
    }
}
