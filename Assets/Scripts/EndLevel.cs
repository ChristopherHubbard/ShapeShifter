using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.tag == "Player")
        {
            Debug.Log("The level is over!!");
            LevelComplete();
        }
    }

    private void LevelComplete()
    {
        throw new NotImplementedException();
    }
}
