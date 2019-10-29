using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    // in Tile
    public int x, y;
    public List<Tile> neighbors;
    void Start()
    {
        //will run after all tiles have been generated
        transform.position = new Vector3(x, 0, y);
        neighbors = new List<Tile>();
        if (x > 0) neighbors.Add(TileGenerator.tileGrid[x - 1, y]);
        if (x < TileGenerator.width - 1) neighbors.Add(TileGenerator.tileGrid[x + 1, y]);
        if (y > 0) neighbors.Add(TileGenerator.tileGrid[x, y - 1]);
        if (y < TileGenerator.height - 1) neighbors.Add(TileGenerator.tileGrid[x, y + 1]);

    }


}
