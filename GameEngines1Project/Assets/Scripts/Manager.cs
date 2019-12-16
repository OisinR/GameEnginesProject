using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public GameObject[] objects;
    public CanvasGroup menu;
    public Dropdown rotAxes;
    GameObject currentObject;
    AudioSource speaker;
    AudioAnalyzer aA;
    public Slider pan;
    bool menuUp;


    private void Start()
    {
        speaker = GetComponent<AudioSource>();
        aA = GetComponent<AudioAnalyzer>();
        RotationRingsSelection(0);
    }

    void Update()
    {
        speaker.panStereo = pan.value;

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!menuUp)
            {
                menu.alpha = 0f;
                menu.blocksRaycasts = false;
                menuUp = !menuUp;
            }

            else
            {
                menu.alpha = 1f;
                menu.blocksRaycasts = true;
                menuUp = !menuUp;
            }
        }

    }
    
    public void ChannelUIChange(int index)
    {
        if (index == 0)
        {
            aA.channel = Channel.Stereo;
        }
        if (index == 1)
        {
            aA.channel = Channel.left;
        }
        if (index == 2)
        {
            aA.channel = Channel.Right;
        }
    }

    public void RotationRingsSelection(int index)
    {
        currentObject = objects[index];
        if (currentObject.GetComponent<Rotate>().direction == Direction.up)
        {
            rotAxes.value = 0;
        }
        if (currentObject.GetComponent<Rotate>().direction == Direction.left)
        {
            rotAxes.value = 1;
        }
        if (currentObject.GetComponent<Rotate>().direction == Direction.right)
        {
            rotAxes.value = 2;
        }
        if (currentObject.GetComponent<Rotate>().direction == Direction.down)
        {
            rotAxes.value = 3;
        }

    }

    public void RotationAxes(int index)
    {
        if (index == 0)
        {
            currentObject.GetComponent<Rotate>().direction = Direction.up;
        }
        if (index == 1)
        {
            currentObject.GetComponent<Rotate>().direction = Direction.left;
        }
        if (index == 2)
        {
            currentObject.GetComponent<Rotate>().direction = Direction.right;
        }
        if (index == 3)
        {
            currentObject.GetComponent<Rotate>().direction = Direction.down;
        }
    }
	
}

