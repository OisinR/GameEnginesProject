using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent (typeof (AudioSource))]
public class AudioAnalyzer2 : MonoBehaviour
{
    AudioSource speaker;
    public static float[] samples = new float[512];
    public static float[] freqBand = new float[8];
    public static float[] bandBuffer = new float[8];
    float[] bufferDecrease = new float[8];

    void Start()
    {
        speaker = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        GetSpectrumData();
        MakeFreqBands();
        BandBuffer();
    }
	
    void GetSpectrumData()
    {
        speaker.GetSpectrumData(samples, 0, FFTWindow.Blackman);
    }

    void MakeFreqBands()
    {
        int count = 0;
        for (int i = 0; i < 8; i++)
        {
            float average = 0;
            int sampleCount = (int)Mathf.Pow(2, i) * 2;

            if(i == 7)
            {
                sampleCount += 2;
            }
            for(int j = 0; j < sampleCount; j++)
            {
                average += samples[count] * (count + 1);
                count++;
            }

            average /= count;
            freqBand[i] = average * 10;
        }
    }

    void BandBuffer()
    {
        for (int g = 0; g < 8; g ++)
        {
            if(freqBand [g] > bandBuffer [g])
            {
                bandBuffer[g] = freqBand[g];
                bufferDecrease[g] = 0.005f;
            }
            if (freqBand[g] < bandBuffer[g])
            {
                bandBuffer[g] -= bufferDecrease[g];
                bufferDecrease[g] *= 1.2f;

            }
        }
    }



}
