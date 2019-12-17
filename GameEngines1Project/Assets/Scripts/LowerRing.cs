using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowerRing : MonoBehaviour
{
    //due to the proBuilder Pipe having it's origin off to the side, need to have this to stay centered
    Vector3 startPos = new Vector3(5.94f, -1.47f, 0);
    bool  canGO;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            canGO = true;
        }
        if (canGO)
        {
            transform.position = Vector3.Lerp(transform.position, startPos, Time.deltaTime);
        }
    }
	
}
