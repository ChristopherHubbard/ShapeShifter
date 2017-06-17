using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject myPlayer;
    private Vector3 offset;

    public bool CanMoveY { get; set; }

    // Use this for initialization
    private void Start()
    {
        myPlayer = GameObject.Find("Player");
        offset = transform.position - myPlayer.transform.position;
        CanMoveY = true;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        float newY = transform.position.y;

        if(CanMoveY)
        {
            newY = myPlayer.transform.position.y + offset.y;
        }
        transform.position = new Vector3(myPlayer.transform.position.x + offset.x, newY, myPlayer.transform.position.z + offset.z);
    }
}
