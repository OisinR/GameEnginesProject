﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParamCube2 : MonoBehaviour
{
    public int band;
    public float startScale, scaleMult;
    public bool useBuffer, use64;
    public Color cColour;
    Material mat;

    private void Start()
    {
        mat = GetComponentInChildren<MeshRenderer>().materials[0];
        mat.EnableKeyword("_EMISSION");
    }

    void Update()
    {
        if (use64)
        {
            if (useBuffer)
            {
                transform.localScale = new Vector3((AudioAnalyzer2.bandBuffer[band] * scaleMult), (AudioAnalyzer2.bandBuffer[band] * scaleMult), (AudioAnalyzer2.bandBuffer[band] * scaleMult) + startScale);

                Color colour = new Color(1, 0, 0, 1);
                mat.SetColor("_EmissionColor", colour * AudioAnalyzer2.audioBand[band] * 10);
            }
            else
            {
                transform.localScale = new Vector3(transform.localScale.x, (AudioAnalyzer2.freqBand[band] * scaleMult) + startScale, transform.localScale.z);

                Color colour = new Color(AudioAnalyzer2.bandBuffer[band], AudioAnalyzer2.bandBuffer[band], AudioAnalyzer2.bandBuffer[band]);
                mat.SetColor("_EmissionColor", colour * AudioAnalyzer2.audioBand64[band] * 10);
            }
        }
        else
        {
            if (useBuffer)
            {
                transform.localScale = new Vector3((AudioAnalyzer2.bandBuffer64[band] * scaleMult) + startScale, (AudioAnalyzer2.bandBuffer64[band] * scaleMult) + startScale, (AudioAnalyzer2.bandBuffer64[band] * scaleMult) + startScale);

                Color colour = new Color(0, 0, 1, 1);
                mat.SetColor("_EmissionColor", colour * AudioAnalyzer2.audioBand64[band] * 10);
            }
            else
            {
                transform.localScale = new Vector3(transform.localScale.x, (AudioAnalyzer2.freqBand64[band] * scaleMult) + startScale, transform.localScale.z);

                Color colour = new Color(AudioAnalyzer2.bandBuffer64[band], AudioAnalyzer2.bandBuffer64[band], AudioAnalyzer2.bandBuffer64[band]);
                mat.SetColor("_EmissionColor", colour * AudioAnalyzer2.audioBand64[band] * 10);
            }
        }
    }
	
}