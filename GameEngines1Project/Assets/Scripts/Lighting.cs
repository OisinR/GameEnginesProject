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
        //gets brighter and darker in time with the band its on
        bulb.intensity = (AudioAnalyzer.bandBuffer[band] * (max - min)) + min;
    }
	
}
