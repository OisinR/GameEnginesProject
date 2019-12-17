using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale : MonoBehaviour
{
    
    GameObject[] allObjects;
    bool start, canGO;

    void Start()
    {
        //grabs all the sphere gameObjects so can do the "explosion"  at the start
        allObjects = GameObject.FindGameObjectsWithTag("Sphere");
    }

    
    void Update()
    {
        if (!start)
        {
            //After everything is made in start, Set all the spheres to tiny
            foreach (GameObject go in allObjects)
            {
                go.transform.localScale = new Vector3(0.0001f, 0.0001f, 0.0001f);
            }
            start = true;
        }
        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            canGO = true;
        }

        if (allObjects[0].transform.localScale.x < 1 && canGO)
        {
            //and then scale them back up to what theyre meant to be
            foreach (GameObject go in allObjects)
            {
                go.transform.localScale = Vector3.Slerp(go.transform.localScale, new Vector3(1, 1, 1), 1 * Time.deltaTime);

            }
        }
    }
	
}
