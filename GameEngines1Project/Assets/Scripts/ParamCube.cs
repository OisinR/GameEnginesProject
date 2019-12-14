using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParamCube : MonoBehaviour
{
    public int band;
    public float startScale, scaleMult;
    public bool useBuffer, use64;
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
                transform.localScale = new Vector3(transform.localScale.x, (AudioAnalyzer2.bandBuffer[band] * scaleMult) + startScale, transform.localScale.z);

                Color colour = new Color(AudioAnalyzer2.bandBuffer[band], AudioAnalyzer2.bandBuffer[band], AudioAnalyzer2.bandBuffer[band]);
                mat.SetColor("_EmissionColor", colour);
            }
            else
            {
                transform.localScale = new Vector3(transform.localScale.x, (AudioAnalyzer2.freqBand[band] * scaleMult) + startScale, transform.localScale.z);

                Color colour = new Color(AudioAnalyzer2.bandBuffer[band], AudioAnalyzer2.bandBuffer[band], AudioAnalyzer2.bandBuffer[band]);
                mat.SetColor("_EmissionColor", colour);
            }
        }
        else
        {
            if (useBuffer)
            {
                transform.localScale = new Vector3(transform.localScale.x, (AudioAnalyzer2.bandBuffer64[band] * scaleMult) + startScale, transform.localScale.z);

                Color colour = new Color(AudioAnalyzer2.bandBuffer64[band], AudioAnalyzer2.bandBuffer64[band], AudioAnalyzer2.bandBuffer64[band]);
                mat.SetColor("_EmissionColor", colour);
            }
            else
            {
                transform.localScale = new Vector3(transform.localScale.x, (AudioAnalyzer2.freqBand64[band] * scaleMult) + startScale, transform.localScale.z);

                Color colour = new Color(AudioAnalyzer2.bandBuffer64[band], AudioAnalyzer2.bandBuffer64[band], AudioAnalyzer2.bandBuffer64[band]);
                mat.SetColor("_EmissionColor", colour);
            }
        }
    }
	
}
