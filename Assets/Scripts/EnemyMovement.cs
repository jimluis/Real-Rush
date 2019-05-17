using System.Collections;
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
        print("Starting patrol");

        foreach (Waypoint waypoint in path)
        {

            transform.position = waypoint.transform.position;
          //  print(">>> Inside - waypoint.name: " + waypoint.name);
            yield return new WaitForSeconds(2f);
        }
        print("Ending patrol");
    }

}
