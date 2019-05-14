using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{

    [SerializeField] Waypoint startWaypoint;
    [SerializeField] Waypoint endWayPoint;
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();
    private List<Waypoint> path = new List<Waypoint>();



    bool isRunning = true;
    Waypoint searchCenter;

    Vector2Int[] directions = { 
        Vector2Int.up, 
        Vector2Int.right, 
        Vector2Int.down, 
        Vector2Int.left };

    public List<Waypoint> GetPath()
    {
        LoadBlocks();
        ColorStartAndEnd();
        BreadthFirstSeach();
        CreatePath();
        return path;
    }


    private void CreatePath()
    {
        path.Add(endWayPoint);

        Waypoint previous = endWayPoint.exploreFrom;

        while(previous != startWaypoint)
        {
            path.Add(previous);
            previous = previous.exploreFrom;
        }

        path.Add(startWaypoint);
        path.Reverse();
    }

    private void BreadthFirstSeach()
    {
        queue.Enqueue(startWaypoint);

        while(queue.Count > 0 && isRunning)
        {
            searchCenter = queue.Dequeue();
            Debug.Log("Searching for: " + searchCenter);
            searchCenter.isExplored = true;

            if (searchCenter == endWayPoint)
            {
                isRunning = false;
                Debug.Log("endWayPoint found!");
                break;
            }

            ExploreNeighbours();



        }

        Debug.Log("Finished Exploring?");
    }

    private void ExploreNeighbours()
    {

        if (!isRunning)
            return;

        foreach(Vector2Int direction in directions)
        {
            Vector2Int neighboursCoordinates = searchCenter.GetGridPos() + direction;
            Debug.Log("neighboursCoordinates: " + neighboursCoordinates);

            if(grid.ContainsKey(neighboursCoordinates))
                EnqueueNewNeighbours(neighboursCoordinates);
          
            else
                Debug.Log("Nothing to explore: " + neighboursCoordinates);
            

            //print("Exploring: " + neighboursCoordinates);
        }
    }

    private void EnqueueNewNeighbours(Vector2Int neighboursCoordinates)
    {
        Waypoint neighbour = grid[neighboursCoordinates];

        if (!neighbour.isExplored && !queue.Contains(neighbour))
        {
            neighbour.SetTopColor(Color.blue);
            queue.Enqueue(neighbour);
            neighbour.exploreFrom = searchCenter;
            Debug.Log("Enqueue neighbour: " + neighbour);
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
                Debug.Log("Overlapping block size: " + waypoint.GetGridPos());

            }

        }

        Debug.Log("Loaded dictionary size: " + grid.Count);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
