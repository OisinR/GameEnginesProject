using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    bool doneyet;
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
            doneyet = true;
            speaker.Stop();
        }

        if(Input.GetButtonDown("Jump") && !speaker.isPlaying)
        {
            Debug.Log(12341);
            speaker.Play();
        }
    }
	
}
