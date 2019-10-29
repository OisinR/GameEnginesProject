using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FloodFill : MonoBehaviour
{
    //pick start cell, add to list and flag as visited
    public Tile currentTile,lastTile;
    public Tile[] neighbours;
    
    public List<Tile> visited = new List<Tile>();

    private void Start()
    {
        currentTile = TileGenerator.tileGrid[Random.Range(0,TileGenerator.height), Random.Range(0,TileGenerator.width)];
        
        Carve();
    }


    //choose a viable neighbour : hasnt been visited and isnt adjacent to a tile that has been

    //after carving into a tile, remember the direction of the carve and disable the tiles to the side

    //carve into neighbour and repeat

    //if dont find viable neighbour, remove from list and flag as visited

    public List<Tile> tiles = new List<Tile>();

    private void Update()
    {
        

        if (TileGenerator.cells.Count != visited.Count)
        {
            Debug.Log(1);
            List<Tile> unmade = new List<Tile>();

            foreach (Tile i in currentTile.neighbors)
            {
                if (canCarve(i) && !tiles.Contains(i))
                {
                    tiles.Add(i);
                    unmade.Add(i);
                }

            }
            if (unmade.Count == 0)
            {
                if (tiles.Contains(currentTile))
                {
                    Debug.Log(2);
                    tiles.Remove(currentTile);
                }

                currentTile = lastTile;
                Debug.Log(3);
                currentTile = tiles[Random.Range(0, tiles.Count)];
            }
            else
            {
                lastTile = currentTile;
                currentTile = unmade[Random.Range(0, unmade.Count)];
                Debug.Log(4);
            }
            

            if (!visited.Contains(currentTile))
            {
                Carve();
            }

        }

    }

    bool canCarve(Tile tile)
    {
        foreach (Tile i in tile.neighbors)
        {
            if (visited.Contains(i))
            {
                if(i != currentTile)
                {
                    return false;
                }
                    
                  
            }
        }
        
        return true;
        
        
    }

        
    

    void Carve()
    {


            currentTile.GetComponent<MeshRenderer>().enabled = true;
        
        visited.Add(currentTile);
    }





}
