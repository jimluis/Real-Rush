using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField] List<Waypoint> path;
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(FollowPath());
        //print("Back at Start");
    }

    IEnumerator FollowPath()
    {
        foreach (Waypoint waypoint in path)
        {
            print("Starting patrol");
            transform.position = waypoint.transform.position;
            print("waypoint.name: " + waypoint.name);
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
