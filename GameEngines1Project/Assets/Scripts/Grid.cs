using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public float[,] grid;
    int Vertical, Horizontal, Columns, Rows;
    public GameObject tile;

    void Start()
    {
        Vertical = 10;
        Horizontal = 20;
        Columns = Horizontal * 2;
        Rows = Vertical * 2;
        grid = new float[Columns, Rows];
        for (int i = 0; i < Columns; i++)
        {
            for (int j = 0; j < Rows; j++)
            {
                SpawnTile(i, j, grid[i, j]);
            }
        }
    }



    private void SpawnTile(int x, int y, float value)
    {
        GameObject g = Instantiate(tile);// ("X: "+x+ "Y: "+ y);
        g.transform.position = new Vector3(x, 0, y);

    }

}
