using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormCubes : MonoBehaviour
{
    public GameObject cubePrefab;
    public float radius = 50;
    public float rotaion = 30;
    public bool use64;


    void Start()
    {
        if (use64)
        {
            float theta = (Mathf.PI * 2.0f) / (float)AudioAnalyzer2.bandBuffer64.Length;
            for (int i = 0; i < AudioAnalyzer2.bandBuffer64.Length; i += 1)
            {
                Vector3 p = new Vector3(Mathf.Sin(theta * i) * radius, 0, Mathf.Cos(theta * i) * radius);
                p = transform.TransformPoint(p);
                Quaternion q = Quaternion.AngleAxis(theta * i * Mathf.Rad2Deg, Vector3.up);
                q = transform.rotation * q;

                GameObject cube = Instantiate(cubePrefab);
                cube.transform.SetPositionAndRotation(p, q);
                cube.transform.localScale = new Vector3(0.5f, 1f, 0.5f);
                cube.transform.parent = this.transform;
                ParamCube pC = cube.AddComponent<ParamCube>();
                pC.band = i;
                pC.startScale = 0.5f;
                pC.scaleMult = 0.5f;

                //elements.Add(cube);
            }
        }
        else
        {
            float theta = (Mathf.PI * 2.0f) / (float)AudioAnalyzer2.bandBuffer.Length;
            for (int i = 0; i < AudioAnalyzer2.bandBuffer.Length; i += 1)
            {
                Vector3 p = new Vector3(Mathf.Sin(theta * i) * radius, 0, Mathf.Cos(theta * i) * radius);
                p = transform.TransformPoint(p);
                Quaternion q = Quaternion.AngleAxis(theta * i * Mathf.Rad2Deg, Vector3.up);
                q = transform.rotation * q;

                GameObject cube = Instantiate(cubePrefab);
                cube.transform.SetPositionAndRotation(p, q);
                cube.transform.localScale = new Vector3(0.5f, 1f, 0.5f);
                cube.transform.parent = this.transform;
                ParamCube pC = cube.AddComponent<ParamCube>();
                pC.use64 = true;
                pC.useBuffer = true;
                pC.band = i;
                pC.startScale = 0.3f;
                pC.scaleMult = 0.25f;

                //elements.Add(cube);
            }
        }
    }

    
    void Update()
    {
        transform.Rotate(Vector3.up, rotaion * Time.deltaTime);
    }
	
}
