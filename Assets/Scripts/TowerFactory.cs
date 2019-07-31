using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] int towerLimit = 5;
    [SerializeField] Tower towerToPlace;
    [SerializeField] Transform towerParentTransform;
    Queue<Tower> towerQueue = new Queue<Tower>();
     
    public void AddTower(Waypoint baseWayPoint)
    {
        //Debug.Log("AddTower - numTowers: "+ numTowers+ " - towerLimit" + towerLimit);

        if (towerQueue.Count < towerLimit)
            InstantiateNewTower(baseWayPoint);
        else 
            MoveExistingTower(baseWayPoint);
        

    }

    private void InstantiateNewTower(Waypoint baseWayPoint)
    {
        //Debug.Log("InstantiateNewTower");
        Tower newTower = Instantiate(towerToPlace, baseWayPoint.transform.position, Quaternion.identity);
        newTower.transform.parent = towerParentTransform.transform;
        baseWayPoint.isPlaceable = false;
        newTower.baseWaypoint = baseWayPoint;

        //put the new tower on the queue
        towerQueue.Enqueue(newTower);
        //Debug.Log("towerQueue.Count: "+ towerQueue.Count);
    }

    private void MoveExistingTower(Waypoint newbaseWayPoint)
    {
        //take bottom tower off Queue
        Tower oldTower = towerQueue.Dequeue();

        //set the placeable flags
        oldTower.baseWaypoint.isPlaceable = true;
        newbaseWayPoint.isPlaceable = false;

        oldTower.baseWaypoint = newbaseWayPoint;
        oldTower.transform.position = newbaseWayPoint.transform.position;
        //put the old tower on top of the queue
        towerQueue.Enqueue(oldTower);
        Debug.Log("Max tower reached");
    }
}
