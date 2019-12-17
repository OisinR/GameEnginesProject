using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class BloomControl : MonoBehaviour
{
    PostProcessVolume volume;
    public Slider slider;

    Bloom bloomLayer;

    void Start()
    {
        //some weird stuff to get it working
        volume = GetComponent<PostProcessVolume>();
        volume.profile.TryGetSettings(out bloomLayer);
    }

    
    void Update()
    {
        bloomLayer.intensity.value = slider.value;
    }
	
}
