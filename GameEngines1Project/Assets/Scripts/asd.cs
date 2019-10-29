﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class asd : MonoBehaviour
{/*
    /// The random dungeon generator.
    ///
    /// Starting with a stage of solid walls, it works like so:
    ///
    /// 1. Place a number of randomly sized and positioned rooms. If a room
    ///    overlaps an existing room, it is discarded. Any remaining rooms are
    ///    carved out.
    /// 2. Any remaining solid areas are filled in with mazes. The maze generator
    ///    will grow and fill in even odd-shaped areas, but will not touch any
    ///    rooms.
    /// 3. The result of the previous two steps is a series of unconnected rooms
    ///    and mazes. We walk the stage and find every tile that can be a
    ///    "connector". This is a solid tile that is adjacent to two unconnected
    ///    regions.
    /// 4. We randomly choose connectors and open them or place a door there until
    ///    all of the unconnected regions have been joined. There is also a slight
    ///    chance to carve a connector between two already-joined regions, so that
    ///    the dungeon isn't single connected.
    /// 5. The mazes will have a lot of dead ends. Finally, we remove those by
    ///    repeatedly filling in any open tile that's closed on three sides. When
    ///    this is done, every corridor in a maze actually leads somewhere.
    ///
    /// The end result of this is a multiply-connected dungeon with rooms and lots
    /// of winding corridors.
    /// 



    public GameObject floor;

    public int numRoomTries;

    /// The inverse chance of adding a connector between two regions that have
    /// already been joined. Increasing this leads to more loosely connected
    /// dungeons.
    public int extraConnectorChance => 20;

    /// Increasing this allows rooms to be larger.
    public int roomExtraSize => 0;

    public int windingPercent => 0;

    Rect[] _rooms;

    /// For each open position in the dungeon, the index of the connected region
    /// that that position is a part of.
    int[] _regions;

    /// The index of the current region being carved.
    int _currentRegion = -1;

    void generate()
    {
        if (stage.width % 2 == 0 || stage.height % 2 == 0)
        {
            //throw new ArgumentError("The stage must be odd-sized.");
        }

        //bindStage(stage);

        fill(Tiles.wall);
        _regions = new Array2D(stage.width, stage.height);

        _addRooms();

        // Fill in all of the empty space with mazes.
        for (var y = 1; y < bounds.height; y += 2)
        {
            for (var x = 1; x < bounds.width; x += 2)
            {
                var pos = new Vector2(x, y);
                if (getTile(pos) != Tiles.wall) continue;
                _growMaze(pos);
            }
        }

        _connectRegions();
        _removeDeadEnds();

        _rooms.forEach(onDecorateRoom);
    }

    void onDecorateRoom(Rect room) { }

    /// Implementation of the "growing tree" algorithm from here:
    /// http://www.astrolog.org/labyrnth/algrithm.htm.
    /// 



    Vector2 lastdirection;

    void _growMaze(Vector2 start)
    {
        
        List<Vector2> cells = new List<Vector2>();


        //Vector2 lastdirection;

        _startRegion();
        _carve(start);
    
        //adds the cell we are currently in
        cells.Add(start);


        while (cells.Count > 0)
        {
            Vector2 cell = cells.Last();


            //
            List<Vector2> Directions = new List<Vector2> {Vector2.up, Vector2.left, Vector2.down, Vector2.right };


            // See which adjacent cells are open.

            //
            List<Vector2> unmadeCells = new List<Vector2>();



            foreach (Vector2 direction in Directions)
                {
                    if (canCarve(cell, direction)) unmadeCells.Add(direction);
                }

            if (unmadeCells != null)
            {
                // Based on how "windy" passages are, try to prefer carving in the
                // same direction.
                Vector2 direction;
                if (unmadeCells.Contains(lastdirection) && Random.Range(0,100) > windingPercent)
                {
                    direction = lastdirection;
                }
                else
                {

                    direction = unmadeCells[Random.Range(0,unmadeCells.Count)];
                    //direction = Random.item(unmadeCells);
                }

                _carve(cell + direction, cell);
                _carve(cell + direction * 2, cell);

                cells.Add(cell + direction * 2);
                lastdirection = direction;
            }
            else
            {
                // No adjacent uncarved cells.
                cells.Remove(cells.Last());


                //cells.removeLast();



                // This path has ended.
                lastdirection  = new Vector2(0,0);
            }
        }
    }

    void _carve(Vector2 pos, GameObject type)
    {
        if (type == null)
        {
            type = floor;
            Instantiate(floor, new Vector3(pos.x,0,pos.y), Quaternion.identity);
        }


        //setTile(pos, type);
        _regions[pos] = _currentRegion;
    }



    /// Places rooms ignoring the existing maze corridors.
    void _addRooms()
    {
        for (var i = 0; i < numRoomTries; i++)
        {
            // Pick a random room size. The funny math here does two things:
            // - It makes sure rooms are odd-sized to line up with maze.
            // - It avoids creating rooms that are too rectangular: too tall and
            //   narrow or too wide and flat.
            // TODO: This isn't very flexible or tunable. Do something better here.
            var size = rng.range(1, 3 + roomExtraSize) * 2 + 1;
            var rectangularity = rng.range(0, 1 + size ~/ 2) * 2;
            var width = size;
            var height = size;
            if (rng.oneIn(2))
            {
                width += rectangularity;
            }
            else
            {
                height += rectangularity;
            }

            var x = rng.range((bounds.width - width) ~/ 2) * 2 + 1;
            var y = rng.range((bounds.height - height) ~/ 2) * 2 + 1;

            var room = new Rect(x, y, width, height);

            var overlaps = false;
      for (var other in _rooms)
            {
                if (room.distanceTo(other) <= 0)
                {
                    overlaps = true;
                    break;
                }
            }

            if (overlaps) continue;

            _rooms.add(room);

            _startRegion();
      for (var pos in new Rect(x, y, width, height))
            {
                _carve(pos);
            }
        }
    }

    void _connectRegions()
    {
        // Find all of the tiles that can connect two (or more) regions.
        var connectorRegions = < Vec, Set< int >>{ };
    for (var pos in bounds.inflate(-1))
        {
            // Can't already be part of a region.
            if (getTile(pos) != Tiles.wall) continue;

            var regions = new Set<int>();
      for (var direction in direction.CARDINAL)
            {
                var region = _regions[pos + direction];
                if (region != null) regions.add(region);
            }

            if (regions.length < 2) continue;

            connectorRegions[pos] = regions;
        }

        var connectors = connectorRegions.keys.toList();

        // Keep track of which regions have been merged. This maps an original
        // region index to the one it has been merged to.
        var merged = { };
        var openRegions = new Set<int>();
        for (var i = 0; i <= _currentRegion; i++)
        {
            merged[i] = i;
            openRegions.add(i);
        }

        // Keep connecting regions until we're down to one.
        while (openRegions.length > 1)
        {
            var connector = rng.item(connectors);

            // Carve the connection.
            _addJunction(connector);

            // Merge the connected regions. We'll pick one region (arbitrarily) and
            // map all of the other regions to its index.
            var regions = connectorRegions[connector]
                .map((region) => merged[region]);
            var dest = regions.first;
            var sources = regions.skip(1).toList();

            // Merge all of the affected regions. We have to look at *all* of the
            // regions because other regions may have previously been merged with
            // some of the ones we're merging now.
            for (var i = 0; i <= _currentRegion; i++)
            {
                if (sources.contains(merged[i]))
                {
                    merged[i] = dest;
                }
            }

            // The sources are no longer in use.
            openRegions.removeAll(sources);

            // Remove any connectors that aren't needed anymore.
            connectors.removeWhere((pos) {
                // Don't allow connectors right next to each other.
                if (connector - pos < 2) return true;

                // If the connector no long spans different regions, we don't need it.
                var regions = connectorRegions[pos].map((region) => merged[region])
                    .toSet();

                if (regions.length > 1) return false;

                // This connecter isn't needed, but connect it occasionally so that the
                // dungeon isn't singly-connected.
                if (rng.oneIn(extraConnectorChance)) _addJunction(pos);

                return true;
            });
    }
}

void _addJunction(Vec pos)
{
    if (rng.oneIn(4))
    {
        setTile(pos, rng.oneIn(3) ? Tiles.openDoor : Tiles.floor);
    }
    else
    {
        setTile(pos, Tiles.closedDoor);
    }
}

void _removeDeadEnds()
{
    var done = false;

    while (!done)
    {
        done = true;

      for (var pos in bounds.inflate(-1))
        {
            if (getTile(pos) == Tiles.wall) continue;

            // If it only has one exit, it's a dead end.
            var exits = 0;
        for (var direction in direction.CARDINAL)
            {
                if (getTile(pos + direction) != Tiles.wall) exits++;
            }

            if (exits != 1) continue;

            done = false;
            setTile(pos, Tiles.wall);
        }
    }
}

/// Gets whether or not an opening can be carved from the given starting
/// [Cell] at [pos] to the adjacent Cell facing [direction]. Returns `true`
/// if the starting Cell is in bounds and the destination Cell is filled
/// (or out of bounds).</returns>
private bool canCarve(Vector2 pos, Vector2 direction)
{
    // Must end in bounds.
    if (!bounds.contains(pos + direction * 3)) return false;

    // Destination must not be open.
    return getTile(pos + direction * 2) == Tiles.wall;
}

void _startRegion()
{
    _currentRegion++;
}
*/

}