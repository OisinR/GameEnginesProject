using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeMaker : MonoBehaviour
{
    /*
        Start at startPos
        Set self as visited
        Set beyond border as visited
        Choose random direrction
        Continue in direction until hit a visited tile or you leave a two unit gap between visited tiles



            List<GameObject> cells;
    List<GameObject> visitedCells;

    public int windingPercent => 0;



    private void Update()
    {
        //_startRegion();
        //_carve(start);

        //adds the cell we are currently in
        //cells.Add(start);



        //add the starting tile to the list of visited tiles

        if (cells.Count > 0)
        {
            GameObject cell = cells.Last();
            // See which adjacent cells are open.

            //
            List<GameObject> unmadeCells = new List<GameObject>();



            foreach (Tile direction in TileGenerator.tileGrid)
            {
                if (canCarve(cell, direction)) unmadeCells.Add(cell);
            }



            if (unmadeCells != null)
            {
                // Based on how "windy" passages are, try to prefer carving in the
                // same direction.
                Vector3 direction;

                //if can continue current path
                if (unmadeCells.Contains(lastdirection) && Random.Range(0, 100) > windingPercent)
                {
                    direction = lastdirection;
                }
                else
                {
                    //otherwise pick random unvisited cell passed and start again
                    direction = unmadeCells[Random.Range(0, unmadeCells.Count)];
                    //direction = Random.item(unmadeCells);
                }

                _carve(cell + direction, cell);
                _carve(cell + direction * 2, cell);

                cells.Add(cell + direction * 2);
                lastdirection = direction;
            }
            else
            {
                // If there are no adjacent uncarved cells, remove from list
                cells.Remove(cells.Last());

                // This path has ended.
                lastdirection = new Vector3(0, 0, 0);
            }
        }
    }

    private bool canCarve(GameObject pos, Vector3 direction)
    {
        // Must end in bounds.
        if (!cells.Contains(pos)) return false;


        // Destination must not be open.
        //return getTile(pos + direction * 2) == Tiles.wall;

        return visitedCells.Contains(pos);
    }


    void _carve(Vector3 pos, GameObject type)
    {
        if (!type.GetComponent<MeshRenderer>().enabled)
        {
            type.GetComponent<MeshRenderer>().enabled = true;
            visitedCells.Add(type);
            //Instantiate(floor, new Vector3(pos.x, 0, pos.y), Quaternion.identity);
        }


        //setTile(pos, type);
       // _regions[pos] = _currentRegion;
    }








        

    
    [1][1][1][1][1][1][1]
    [1][*][0][0][0][0][1]
    [1][*][0][0][0][0][1]
    [1][*][0][0][0][0][1]
    [1][*][0][0][0][0][1]
    [1][1][1][1][1][1][1]

    [1][1][1][1][1][1][1]
    [1][*][0][0][0][0][1]
    [1][*][0][0][0][0][1]
    [1][*][0][0][0][0][1]
    [1][*][*][*][*][*][1]
    [1][1][1][1][1][1][1]

    [1][1][1][1][1][1][1]
    [1][*][0][0][0][0][1]
    [1][*][0][0][0][0][1]
    [1][*][0][0][0][*][1]
    [1][*][*][*][*][*][1]
    [1][1][1][1][1][1][1]

    [1][1][1][1][1][1][1]
    [1][*][0][0][0][0][1]
    [1][*][0][0][0][0][1]
    [1][*][0][0][0][*][1]
    [1][*][*][*][*][*][1]
    [1][1][1][1][1][1][1]


 */
}
