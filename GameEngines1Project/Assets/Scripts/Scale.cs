using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale : MonoBehaviour
{
    GameObject[] allObjects;
    bool start, canGO;
    float counter;
    void Start()
    {
        allObjects = GameObject.FindGameObjectsWithTag("Sphere");
        counter = 0.01f;
    }

    
    void Update()
    {
        if (!start)
        {
            foreach (GameObject go in allObjects)
            {
                go.transform.localScale = new Vector3(0.0001f, 0.0001f, 0.0001f);
            }
            start = true;
        }
        if(Input.GetKeyDown(KeyCode.P))
        {
            canGO = true;
        }

        if (allObjects[0].transform.localScale.x < 1 && canGO)
        {
            foreach (GameObject go in allObjects)
            {
                go.transform.localScale = Vector3.Slerp(go.transform.localScale, new Vector3(1, 1, 1), 1 * Time.deltaTime);

                //go.transform.localScale = new Vector3(counter, counter, counter);
            }
            //counter = counter + 0.01f; ;
        }
    }
	
}
