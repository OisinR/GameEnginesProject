using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParamCube : MonoBehaviour
{
    public int band;
    public int multNo = 10;
    public float startScale, scaleMult;
    public bool  use64;
    public Color cColour;
    Material mat;

    private void Start()
    {
        mat = GetComponentInChildren<MeshRenderer>().materials[0];

        //Enable emission
        mat.EnableKeyword("_EMISSION");
    }

    void Update()
    {
        if (use64)
        {
            //Do the stretching 
            transform.localScale = new Vector3(transform.localScale.x, (AudioAnalyzer.bandBuffer[band] * scaleMult) + startScale, transform.localScale.z);

            //then do the colours
            Color colour = new Color(1, 0, 0, 1);
            mat.SetColor("_EmissionColor", colour * AudioAnalyzer.audioBand[band] * multNo);

        }
        else
        {

            transform.localScale = new Vector3(transform.localScale.x, (AudioAnalyzer.bandBuffer64[band] * scaleMult) + startScale, transform.localScale.z);

            Color colour = new Color(0, 0, 1, 1);
            mat.SetColor("_EmissionColor", colour * AudioAnalyzer.audioBand64[band] * multNo);

        }
    }
	
}
