using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{
    //these are static so that Tile can easily access them
    public static Tile[,] tileGrid;
    public static int width = 11;
    public static int height = 11;

    public GameObject tilePrefab;


    void Awake()
    {
        tileGrid = new Tile[width, height];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                GameObject newTileGO = Instantiate(tilePrefab);
                Tile newTile = newTileGO.GetComponent<Tile>();
                tileGrid[x, y] = newTile;
                newTile.x = x;
                newTile.y = y;
            }
        }

    }
}
