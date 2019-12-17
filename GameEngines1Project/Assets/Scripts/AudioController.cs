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
        //If it's not alreay playing, play
        if(Input.GetKeyDown(KeyCode.Space) && !speaker.isPlaying)
        {
            speaker.Play();
        }
    }
	
}
