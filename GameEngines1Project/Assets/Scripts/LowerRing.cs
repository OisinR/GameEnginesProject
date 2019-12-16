using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowerRing : MonoBehaviour
{
    float y = -1.47f;
    Vector3 startPos = new Vector3(5.94f, -1.47f, 0);
    bool  canGO;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            canGO = true;
        }
        if (canGO)
        {
            transform.position = Vector3.Lerp(transform.position, startPos, Time.deltaTime);
        }
    }
	
}
