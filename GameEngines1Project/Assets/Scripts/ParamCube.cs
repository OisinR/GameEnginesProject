using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParamCube : MonoBehaviour
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
                transform.localScale = new Vector3(transform.localScale.x, (AudioAnalyzer.bandBuffer[band] * scaleMult) + startScale, transform.localScale.z);

                Color colour = new Color(1, 0, 0, 1);
                mat.SetColor("_EmissionColor", colour * AudioAnalyzer.audioBand[band] * 100);
            }
            else
            {
                transform.localScale = new Vector3(transform.localScale.x, (AudioAnalyzer.freqBand[band] * scaleMult) + startScale, transform.localScale.z);

                Color colour = new Color(AudioAnalyzer.bandBuffer[band], AudioAnalyzer.bandBuffer[band], AudioAnalyzer.bandBuffer[band]);
                mat.SetColor("_EmissionColor", colour);
            }
        }
        else
        {
            if (useBuffer)
            {
                transform.localScale = new Vector3(transform.localScale.x, (AudioAnalyzer.bandBuffer64[band] * scaleMult) + startScale, transform.localScale.z);

                Color colour = new Color(0, 0, 1, 1);
                mat.SetColor("_EmissionColor", colour * AudioAnalyzer.audioBand64[band] * 100);
            }
            else
            {
                transform.localScale = new Vector3(transform.localScale.x, (AudioAnalyzer.freqBand64[band] * scaleMult) + startScale, transform.localScale.z);

                Color colour = new Color(AudioAnalyzer.bandBuffer64[band], AudioAnalyzer.bandBuffer64[band], AudioAnalyzer.bandBuffer64[band]);
                mat.SetColor("_EmissionColor", colour);
            }
        }
    }
	
}
