using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float rotaion = 30;
    public enum Direction { up, down, left, right  };
    public Direction direction = new Direction();

    void Update()
    {
        if (direction == Direction.up)
        {
            transform.Rotate(Vector3.up, (AudioAnalyzer2.amplitude * 5) * rotaion * Time.deltaTime);
        }
        if (direction == Direction.down)
        {
            transform.Rotate(Vector3.down, (AudioAnalyzer2.amplitude * 5) * rotaion * Time.deltaTime);
        }
        if (direction == Direction.left)
        {
            transform.Rotate(Vector3.left, (AudioAnalyzer2.amplitude * 5) * rotaion * Time.deltaTime);
        }
        if (direction == Direction.right)
        {
            transform.Rotate(Vector3.right, (AudioAnalyzer2.amplitude * 5) * rotaion * Time.deltaTime);
        }


    }
	
}
