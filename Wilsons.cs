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
        map[x, z] = 0;

        RandomWalk();
    }

   
    void RandomWalk()
    {
        
        int cx = Random.Range(2, width - 1);
        int cz = Random.Range(2, depth - 1);

        

        int loop = 0;
        
        while (cx > 0 && cx < width - 1 && cz > 0 && cz < depth - 1 && loop < 5000)
        {
            map[cx, cz] = 0;
            
            int rd = Random.Range(0, directions.Count);
            int nx = cx + directions[rd].x;
            int nz = cz + directions[rd].z;
            if (CountSquareNeighbours(nx, nz) < 2)
            {
                cx = nx;
                cz = nz;
               
            }

          

            loop++;
        }


    }

}
