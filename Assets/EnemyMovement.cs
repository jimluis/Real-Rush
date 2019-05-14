﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        var path = pathfinder.GetPath();

        StartCoroutine(FollowPath(path));
        //print("Back at Start");
    }

    IEnumerator FollowPath(List<Waypoint> path)
    {
        foreach (Waypoint waypoint in path)
        {
            print("Starting patrol");
            transform.position = waypoint.transform.position;
         //   print("waypoint.name: " + waypoint.name);
            yield return new WaitForSeconds(1f);

           
            //InvokeRepeating("printHello", 0f, 1f);
        }
        print("Ending patrol");
    }
    //void printHello()
    //{
    //    print("Hello: ";
    //}
    // Update is called once per frame
    void Update()
    {
        
    }
}
