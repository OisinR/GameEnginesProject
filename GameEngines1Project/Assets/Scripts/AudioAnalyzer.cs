using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Channel { Stereo, left, Right };

[RequireComponent (typeof (AudioSource))]
public class AudioAnalyzer : MonoBehaviour
{
    AudioSource speaker;
    public static float[] samplesL = new float[512];
    public static float[] samplesR = new float[512];

    //8
    public static float[] freqBand = new float[8];
    public static float[] bandBuffer = new float[8];
    public static float[] bufferDecrease = new float[8];
    float[] freqBandHighest = new float[8];
    public static float[] audioBand, bufferBand;

    //64
    public static float[] freqBand64 = new float[64];
    public static float[] bandBuffer64 = new float[64];
    public static float[] bufferDecrease64 = new float[64];
    float[] freqBandHighest64 = new float[64];
    public static float[] audioBand64, bufferBand64;

    public static float amplitude = 0.01f;
    public static float ampBuffer;
    float amplitudeHighest;

    
    public Channel channel = new Channel();

    void Start()
    {
        audioBand = new float[8];
        bufferBand = new float[8];

        audioBand64 = new float[64];
        bufferBand64 = new float[64];

        speaker = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        //gathers samples
        GetSpectrumData();

        //turn those samples into something usable
        MakeFreqBands(channel);
        MakeFreqBands64(channel);

        //and then make them less erratic
        BandBuffer();
        BandBuffer64();

        //then normalise
        CreateAudioBands();
        CreateAudioBands64();

        //and get the amplitude for rotation speed
        GetAmplitude();
    }
	
    void GetSpectrumData()
    {
        speaker.GetSpectrumData(samplesL, 0, FFTWindow.Blackman);
        speaker.GetSpectrumData(samplesR, 1, FFTWindow.Blackman);
    }

    public void MakeFreqBands(Channel channel)
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
                if (channel == Channel.Stereo)
                {
                    average += samplesL[count] + samplesR[count] * (count + 1);
                }
                if (channel == Channel.left)
                {
                    average += samplesL[count] * (count + 1);
                }
                if (channel == Channel.Right)
                {
                    average +=  samplesR[count] * (count + 1);
                }
                count++;
            }

            average /= count;
            freqBand[i] = average * 10;
        }
    }

    public void MakeFreqBands64(Channel channel)
    {
        int count = 0;
        int sampleCount = 1;
        int power = 0;
        for (int i = 0; i < 64; i++)
        {
            float average = 0;
            

            if (i == 16 || i == 32 || i == 40 || i == 48 || i == 56)
            {
                power++;
                sampleCount = (int)Mathf.Pow (2, power);
                if(power == 3)
                {
                    sampleCount -= 2;
                }
            }
            for (int j = 0; j < sampleCount; j++)
            {
                if (channel == Channel.Stereo)
                {
                    average += samplesL[count] + samplesR[count] * (count + 1);
                }
                if (channel == Channel.left)
                {
                    average += samplesL[count] * (count + 1);
                }
                if (channel == Channel.Right)
                {
                    average += samplesR[count] * (count + 1);
                }
                count++;
            }

            average /= count;
            freqBand64 [i] = average * 80;
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

    void BandBuffer64()
    {
        for (int g = 0; g < 64; g ++)
        {
            if(freqBand64 [g] > bandBuffer64 [g])
            {
                bandBuffer64[g] = freqBand64[g];
                bufferDecrease64[g] = 0.005f;
            }
            if (freqBand64[g] < bandBuffer64[g])
            {
                bandBuffer64[g] -= bufferDecrease64[g];
                bufferDecrease64[g] *= 1.2f;

            }
        }
    }


    void CreateAudioBands()
    {
        for (int i = 0; i < 8; i++)
        {
            if (freqBand[i] > freqBandHighest[i])
            {
                freqBandHighest[i] = freqBand[i];
            }
            audioBand[i] = (freqBand[i] / freqBandHighest[i]);
            bufferBand[i] = (bandBuffer[i] / freqBandHighest[i]);
        }
    }

    void CreateAudioBands64()
    {
        for (int i = 0; i < 64; i++)
        {
            if (freqBand64[i] > freqBandHighest64[i])
            {
                freqBandHighest64[i] = freqBand64[i];
            }
            audioBand64[i] = (freqBand64[i] / freqBandHighest64[i]);
            bufferBand64[i] = (bandBuffer64[i] / freqBandHighest64[i]);
        }
    }

    void GetAmplitude()
    {
        float currentAmp = 0;
        float currentAmpBuffer = 0;

        for(int i=0; i<8; i++)
        {
            currentAmp += audioBand[i];
            currentAmpBuffer += bandBuffer[i];
        }
        if(currentAmp > amplitudeHighest)
        {
            amplitudeHighest = currentAmp;
        }
        amplitude = currentAmp / amplitudeHighest;
        if(amplitude == 1)
        {
            //for the start
            amplitude = 0.01f;
        }
        ampBuffer = currentAmpBuffer / amplitudeHighest;

    }


}


