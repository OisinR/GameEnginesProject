using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSlowly : MonoBehaviour
{
    public float min = 0.1f;
    public float max = 1f;

    
    void Update()
    {
        
        transform.Rotate(Vector3.forward, Time.deltaTime);
    }
	
}
