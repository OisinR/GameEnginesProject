using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeBigCubes : MonoBehaviour
{
    public GameObject cubePrefab;
    public float scale = 2;
    GameObject[] cubes = new GameObject[512];
    
    void Start()
    {
        for (int i = 0; i < 512; i++)
        {
            GameObject instance = (GameObject)Instantiate(cubePrefab);
            instance.transform.position = transform.position;
            instance.transform.parent = transform;
            instance.name = "Cube " + i;
            transform.eulerAngles = new Vector3(0, -0.73125f * i, 0);
            instance.transform.position = Vector3.forward * 3;
            cubes[i] = instance;
        }
    }

    
    void Update()
    {
        for (int i = 0; i < 512; i++)
        {
            if (cubes != null)
            {
                cubes[i].transform.localScale = new Vector3(1, AudioAnalyzer2.samplesL[i] * scale,1);
            }
        }
    }
	
}
