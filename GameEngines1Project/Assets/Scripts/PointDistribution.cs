﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PointDistribution : MonoBehaviour
{
    public float scaling = 32;
    public int bandNo;
    public GameObject cubePrefab;
    void Start()
    {
        
        Vector3[] pts = PointsOnSphere(512);
        List<GameObject> uspheres = new List<GameObject>();
        int i = 0;

        foreach (Vector3 value in pts)
        {
            //When we make the cube, also set all variables needed
            GameObject cube = Instantiate(cubePrefab);
            uspheres.Add(cube);
            cube.GetComponent<ParamCube>().band = bandNo;
            uspheres[i].transform.parent = transform;
            uspheres[i].transform.position = value * scaling;
            uspheres[i].transform.LookAt(new Vector3(0, 0, 0));
            i++;
        }
    }


    //Maths for Sphere creation
    Vector3[] PointsOnSphere(int n)
    {
        List<Vector3> upts = new List<Vector3>();
        float inc = Mathf.PI * (3 - Mathf.Sqrt(5));
        float off = 2.0f / n;
        float x = 0;
        float y = 0;
        float z = 0;
        float r = 0;
        float phi = 0;

        for (var k = 0; k < n; k++)
        {
            y = k * off - 1 + (off / 2);
            r = Mathf.Sqrt(1 - y * y);
            phi = k * inc;
            x = Mathf.Cos(phi) * r;
            z = Mathf.Sin(phi) * r;

            upts.Add(new Vector3(x, y, z));
        }
        Vector3[] pts = upts.ToArray();
        return pts;
    }
}



