using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wilsons : Maze
{
    List<MapLocation> directions = new List<MapLocation>() {
                                            new MapLocation(1,0),
                                            new MapLocation(0,1),
                                            new MapLocation(-1,0),
                                            new MapLocation(0,-1) };

    
    public override void Generate()
    {
        //create a starting cell
        int x = Random.Range(2, width - 1);
        int z = Random.Range(2, depth - 1);
        map[x, z] = 2; //existing maze is *not* considered to be part of the drawpath by the crawler


        for(int i = 0; i < 5; i++)
        {
        RandomWalk();
        }
    }

    int CountSquareMazeNeighbours(int x, int z)
    {
        int count = 0;
        for(int d = 0; d < directions.Count; d++)
        {
            int nx = x + directions[d].x;
            int nz = z + directions[d].z;

            if(map[nx, nz] == 2)
            {
                count++;
            }
        }
        return count;
    }
   
    void RandomWalk()
    {
        
        List<MapLocation> inWalk = new List<MapLocation>();


        int cx = Random.Range(2, width - 1);
        int cz = Random.Range(2, depth - 1);

        inWalk.Add(new MapLocation(cx, cz));


        int loop = 0;
        bool validPath = false;
        
        while (cx > 0 && cx < width - 1 && cz > 0 && cz < depth - 1 && loop < 5000 && !validPath)
        {
            map[cx, cz] = 0;
            
            int rd = Random.Range(0, directions.Count);
            int nx = cx + directions[rd].x;
            int nz = cz + directions[rd].z;
            if (CountSquareNeighbours(nx, nz) < 2)
            {
                cx = nx;
                cz = nz;
               inWalk.Add(new MapLocation(cx, cz));
            }

            validPath = CountSquareMazeNeighbours(cx, cz) == 1;

            loop++;
        }

        if (validPath)
        {
            map[cx, cz] = 0;
            Debug.Log("PathFound");

            foreach(MapLocation m in inWalk)
            {
                map[m.x, m.z] = 2;
            }    
                inWalk.Clear();
            
        }
        else
        {
            foreach(MapLocation m in inWalk)
                map[m.x, m.z] = 1;
            inWalk.Clear();
        }
    }

}
