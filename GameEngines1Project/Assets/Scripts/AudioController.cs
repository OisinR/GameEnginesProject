using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{

    AudioSource speaker;
    void Start()
    {
        speaker = GetComponent<AudioSource>();
        //speaker.Play();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {

            speaker.Stop();
        }

        if(Input.GetButtonDown("Jump") && !speaker.isPlaying)
        {
            Debug.Log(speaker.panStereo);
            speaker.Play();
        }
    }
	
}
