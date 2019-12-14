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
            transform.localScale = new Vector3((AudioAnalyzer2.amplitude * maxScale) + startScale, transform.localScale.y, (AudioAnalyzer2.amplitude * maxScale) + startScale);

            Color colour = new Color(AudioAnalyzer2.amplitude * red, AudioAnalyzer2.amplitude * green, AudioAnalyzer2.amplitude * blue);
            mat.SetColor("_EmissionColor", colour);
        }
        else
        {
            transform.localScale = new Vector3((AudioAnalyzer2.ampBuffer * maxScale) + startScale, transform.localScale.y, (AudioAnalyzer2.ampBuffer * maxScale) + startScale);

            Color colour = new Color(AudioAnalyzer2.ampBuffer * red, AudioAnalyzer2.ampBuffer * green, AudioAnalyzer2.ampBuffer * blue);
            mat.SetColor("_EmissionColor", colour);
        }
    }
}
