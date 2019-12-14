using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    bool start;
    
    void Awake()
    {
        transform.localScale = new Vector3(0.001f, 0.001f, 0.001f);
    }

    
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            start = true;
        }

        if(start)
        {
            if(transform.localScale.x < 1)
            {
                transform.localScale = new Vector3(transform.localScale.x + 0.1f, transform.localScale.y + 0.1f, transform.localScale.z + 0.1f);
            }
        }
    }
	
}
