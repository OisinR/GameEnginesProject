using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    public float min, max;
    Material mat;


    void Start()
    {
        
        mat = GetComponent<MeshRenderer>().material;
        mat.EnableKeyword("_EMISSION");
    }


    void Update()
    {
        Color colour = new Color(1, 1, 1, 1);
        mat.SetColor("_EmissionColor", colour * AudioAnalyzer.amplitude);
    }
}
