using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleOnAmp : MonoBehaviour
{
    public float startScale, maxScale;
    public bool useBuffer;
    Material mat;
    public float red, green, blue;

    private void Start()
    {
        mat = GetComponentInChildren<MeshRenderer>().materials[0];
        mat.EnableKeyword("_EMISSION");
    }

    void Update()
    {
        if (useBuffer)
        {
            //
            transform.localScale = new Vector3((AudioAnalyzer.amplitude * maxScale) + startScale, transform.localScale.y, (AudioAnalyzer.amplitude * maxScale) + startScale);

            Color colour = new Color(AudioAnalyzer.amplitude * red, AudioAnalyzer.amplitude * green, AudioAnalyzer.amplitude * blue);
            mat.SetColor("_EmissionColor", colour);
        }
        else
        {
            transform.localScale = new Vector3((AudioAnalyzer.ampBuffer * maxScale) + startScale, transform.localScale.y, (AudioAnalyzer.ampBuffer * maxScale) + startScale);

            Color colour = new Color(AudioAnalyzer.ampBuffer * red, AudioAnalyzer.ampBuffer * green, AudioAnalyzer.ampBuffer * blue);
            mat.SetColor("_EmissionColor", colour);
        }
    }
}
