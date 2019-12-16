using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FormCubes : MonoBehaviour
{
    public Slider rotSpeed;
    public GameObject cubePrefab,  cylen2;
    public float radius = 50;
    public float rotaion = 30;
    public bool use64, cylen;
    public float scaleW = 1.5f;
    public float scaleH = 0.5f;
    public float scaleCyl = 1f;

    void Start()
    {
        if (use64)
        {
            float theta = (Mathf.PI * 2.0f) / (float)AudioAnalyzer.bandBuffer64.Length;
            for (int i = 0; i < AudioAnalyzer.bandBuffer64.Length; i += 1)
            {
                Vector3 p = new Vector3(Mathf.Sin(theta * i) * radius, 0, Mathf.Cos(theta * i) * radius);
                p = transform.TransformPoint(p);
                Quaternion q = Quaternion.AngleAxis(theta * i * Mathf.Rad2Deg, Vector3.up);
                q = transform.rotation * q;

                GameObject cube = Instantiate(cubePrefab);
                cube.transform.SetPositionAndRotation(p, q);
                cube.transform.localScale = new Vector3(scaleW, scaleH, scaleW);
                cube.transform.parent = this.transform;
                if(cylen)
                {
                    GameObject cyl = Instantiate(cylen2);
                    cyl.transform.SetPositionAndRotation(p, q);
                    cyl.transform.localScale = new Vector3(scaleCyl, scaleH, scaleCyl);
                    cyl.transform.parent = this.transform;
                }
                ParamCube pC = cube.AddComponent<ParamCube>();
                pC.band = i;
                pC.useBuffer = true;
                pC.startScale = 0.5f;
                pC.scaleMult = 0.05f;

                //elements.Add(cube);
            }
        }
        else
        {
            float theta = (Mathf.PI * 2.0f) / (float)AudioAnalyzer.bandBuffer.Length;
            for (int i = 0; i < AudioAnalyzer.bandBuffer.Length; i += 1)
            {
                Vector3 p = new Vector3(Mathf.Sin(theta * i) * radius, 0, Mathf.Cos(theta * i) * radius);
                p = transform.TransformPoint(p);
                Quaternion q = Quaternion.AngleAxis(theta * i * Mathf.Rad2Deg, Vector3.up); 
                q = transform.rotation * q;

                GameObject cube = Instantiate(cubePrefab);
                cube.transform.SetPositionAndRotation(p, q);
                cube.transform.localScale = new Vector3(scaleW, scaleH, scaleW);
                cube.transform.parent = this.transform;

                //cube.transform.localRotation = Quaternion.Euler(-90, 0, 0);
                if (cylen)
                {
                    GameObject cyl = Instantiate(cylen2);
                    cyl.transform.SetPositionAndRotation(p, q);
                    cyl.transform.localScale = new Vector3(scaleCyl, scaleH, scaleCyl);
                    cyl.transform.parent = this.transform;
                    //cyl.transform.eulerAngles = new Vector3(-90, transform.rotation.y, transform.rotation.z);
                }
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
        transform.Rotate(Vector3.up, (AudioAnalyzer.amplitude * 5) * rotSpeed.value * rotaion * Time.deltaTime);
        //Debug.Log(AudioAnalyzer.amplitude);
    }
	
}
