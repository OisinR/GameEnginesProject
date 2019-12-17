using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Direction { up, down, left, right };

public class Rotate : MonoBehaviour
{
    public bool useRandom;
    public float rotaion = 30;

    public Direction direction = new Direction();
    public Slider rotSpeed;


    private void Start()
    {
        //If not set to random keep what we set it to, otherwise choose at start
        if(useRandom)
        {
            direction = (Direction)Random.Range(0, 3);
        }
    }

    void Update()
    {
        //Apply rotations

        if (direction == Direction.up)
        {
            transform.Rotate(Vector3.up, (AudioAnalyzer.amplitude * 5) * rotaion * rotSpeed.value * Time.deltaTime);
        }
        if (direction == Direction.down)
        {
            transform.Rotate(Vector3.down, (AudioAnalyzer.amplitude * 5) * rotaion * rotSpeed.value * Time.deltaTime);
        }
        if (direction == Direction.left)
        {
            transform.Rotate(Vector3.left, (AudioAnalyzer.amplitude * 5) * rotaion * rotSpeed.value * Time.deltaTime);
        }
        if (direction == Direction.right)
        {
            transform.Rotate(Vector3.right, (AudioAnalyzer.amplitude * 5) * rotaion * rotSpeed.value * Time.deltaTime);
        }
    }
}
