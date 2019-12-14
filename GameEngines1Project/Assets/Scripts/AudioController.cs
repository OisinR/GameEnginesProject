using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{

    AudioSource speaker;
    void Start()
    {
        speaker = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        if(Input.GetButtonDown("Jump") && !speaker.isPlaying)
        {
            speaker.Play();
        }
    }
	
}
