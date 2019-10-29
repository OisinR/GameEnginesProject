using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FloodFill : MonoBehaviour
{
    //pick start cell, add to list and flag as visited
    public Tile currentTile;
    public Tile[] neighbours;
    public List<Tile> tiles = new List<Tile>();
    public List<Tile> visited = new List<Tile>();

    private void Start()
    {
        currentTile = TileGenerator.tileGrid[Random.Range(0,TileGenerator.height), Random.Range(0,TileGenerator.width)];
        Carve(currentTile);
    }


    //choose a viable neighbour : hasnt been visited and isnt adjacent to a tile that has been

    //after carving into a tile, remember the direction of the carve and disable the tiles to the side

    //carve into neighbour and repeat

    //if dont find viable neighbour, remove from list and flag as visited



    private void Update()
    {
        foreach(Tile i in currentTile.neighbors)
        {
            if(canCarve(i) && !tiles.Contains(i))
            {
                tiles.Add(i);
            }
        }

        currentTile = tiles[Random.Range(0, tiles.Count)];
        Carve(currentTile);
    }

    bool canCarve(Tile tile)
    {
        if(!tile.gameObject.GetComponent<MeshRenderer>().enabled || )
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }

    void Carve(Tile tile)
    {
        currentTile.GetComponent<MeshRenderer>().enabled = true;
        tiles.Add(currentTile);
        visited.Add(currentTile);
    }





}
