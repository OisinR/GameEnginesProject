using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (AudioSource))]
public class AudioAnalyzer2 : MonoBehaviour
{
    AudioSource speaker;
    public static float[] samples = new float[512];


    void Start()
    {
        speaker = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        GetSpectrumData();
    }
	
    void GetSpectrumData()
    {
        speaker.GetSpectrumData(samples, 0, FFTWindow.Blackman);
    }

}
