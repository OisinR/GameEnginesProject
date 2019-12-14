using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighting : MonoBehaviour
{
    public int band;
    public float min, max;
    Light bulb;
    
    
    void Start()
    {
        bulb = GetComponent<Light>();
    }

    
    void Update()
    {
        bulb.intensity = (AudioAnalyzer2.bandBuffer[band] * (max - min)) + min;
    }
	
}
