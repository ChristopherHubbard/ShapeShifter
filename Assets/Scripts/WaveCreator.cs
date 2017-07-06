using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveCreator : MonoBehaviour
{
    public float waveLength;

    private List<SpriteRenderer> waveRenderers = new List<SpriteRenderer>();
    private bool flowing = true;

	// Use this for initialization
	private void Start ()
    {
        List<Transform> waterObjects = new List<Transform>();
        waterObjects.AddRange(GetComponentsInChildren<Transform>());
        
		foreach(Transform waterObject in waterObjects)
        {
            if (waterObject.tag != "WaterBasin")
            {
                waveRenderers.Add(waterObject.GetComponent<SpriteRenderer>());
            }
        }

        StartCoroutine(CreateWave());
    }

    private IEnumerator CreateWave()
    {
        while(flowing)
        {
            yield return new WaitForSecondsRealtime(waveLength);

            foreach (SpriteRenderer waveRenderer in waveRenderers)
            {
                waveRenderer.flipX = !waveRenderer.flipX;
            }
        }
    }
}
