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
        currentTile = TileGenerator.tileGrid[0,0]; //[Random.Range(0,TileGenerator.height), Random.Range(0,TileGenerator.width)];
        
        Carve();
    }


    //choose a viable neighbour : hasnt been visited and isnt adjacent to a tile that has been

    //after carving into a tile, remember the direction of the carve and disable the tiles to the side

    //carve into neighbour and repeat

    //if dont find viable neighbour, remove from list and flag as visited

    public List<Tile> tiles = new List<Tile>();

    private void Update()
    {
        Debug.Log(tiles.Count);

        if (TileGenerator.cells.Count > tiles.Count-2)
        {
            //Debug.Log(1);
            List<Tile> unmade = new List<Tile>();

            foreach (Tile i in currentTile.neighbors)
            {
                if (!tiles.Contains(i) && !visited.Contains(i))
                {
                    if(canCarve(i))
                    {
                        tiles.Add(i);
                        unmade.Add(i);
                    }
                    
                }

            }
            if (unmade.Count == 0)
            {

                //Debug.Log(2);
                tiles.Remove(currentTile);
                


                currentTile = tiles.Last();
            }
            else
            {
                lastTile = currentTile;
                currentTile = tiles.Last();
                //Debug.Log(4);
            }
            

            if (!visited.Contains(currentTile))
            {
                Carve();
            }

        }
        Debug.Log("End");
    }

    bool canCarve(Tile j)
    {
        foreach (Tile i in j.neighbors)
        {
            //Debug.Log(222);
            if (visited.Contains(i) || i.gameObject.GetComponent<MeshRenderer>().enabled)
            {
                if(i != currentTile)
                {
                    Debug.Log(223);
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
