using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{

    [SerializeField] Waypoint startPoint;
    [SerializeField] Waypoint endPoint;
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();


    void Start()
    {
        LoadBlocks();
        ColorStartAndEnd();

    }

    void ColorStartAndEnd()
    {
        startPoint.SetTopColor(Color.green);
        endPoint.SetTopColor(Color.red); 
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
