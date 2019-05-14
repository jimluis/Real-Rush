using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{

    [SerializeField] Waypoint startWaypoint;
    [SerializeField] Waypoint endWayPoint;
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Vector2Int[] directions = { Vector2Int.up, Vector2Int.right, Vector2Int.down, Vector2Int.left };
    Queue<Waypoint> queue = new Queue<Waypoint>();
    bool isRunning = true;

    void Start()
    {
        LoadBlocks();
        ColorStartAndEnd();
        Pathfind();
    }

    private void Pathfind()
    {
        queue.Enqueue(startWaypoint);

        while(queue.Count > 0 && isRunning)
        {
            var searchCenter = queue.Dequeue();
            print("Searching for: " + searchCenter);
            searchCenter.isExplored = true;

            if (searchCenter == endWayPoint)
            {
                isRunning = false;
                print("endWayPoint found!");
                break;
            }

            ExploreNeighbours(searchCenter);



        }

        print("Finished Exploring?");
    }

    private void ExploreNeighbours(Waypoint from)
    {

        if (!isRunning)
            return;

        foreach(Vector2Int direction in directions)
        {
            Vector2Int neighboursCoordinates = from.GetGridPos() + direction;

            try
            {

                    EnqueueNewNeighbours(neighboursCoordinates);
            }
            catch
            {
                print("Nothing to explore: " + neighboursCoordinates);
            }

            //print("Exploring: " + neighboursCoordinates);
        }
    }

    private void EnqueueNewNeighbours(Vector2Int neighboursCoordinates)
    {
        Waypoint neighbour = grid[neighboursCoordinates];

        if (!neighbour.isExplored)
        {
            neighbour.SetTopColor(Color.blue);
            queue.Enqueue(neighbour);
            print("Enqueue neighbour: " + neighbour);
        }

    }

    void ColorStartAndEnd()
    {
        startWaypoint.SetTopColor(Color.green);
        endWayPoint.SetTopColor(Color.red); 
    }

    void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>();

        foreach(Waypoint waypoint in waypoints)
        {
            if (!grid.ContainsKey(waypoint.GetGridPos()))
            { 
                grid.Add(waypoint.GetGridPos(), waypoint);
              //  waypoint.SetTopColor(Color.black);
            }
            else
            { 
            print("Overlapping block size: " + waypoint.GetGridPos());

            }

        }

        print("Loaded dictionary size: " + grid.Count);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
