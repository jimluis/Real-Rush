using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField] float movementPeriod = 0.5f;
    [SerializeField] ParticleSystem deathParticlePrefab;

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
            yield return new WaitForSeconds(movementPeriod);
        }

        print("Ending patrol");
        //If enemy is not destroy by the towers, distroy it
        //after reaching the tower
        DestroyEnemyWhenReachingGoal();
    }


    public void DestroyEnemyWhenReachingGoal()
    {
        var vfx = Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
        vfx.Play();
        float destroyDelay = vfx.main.duration;
        Destroy(vfx.gameObject, destroyDelay);
        Destroy(this.gameObject);
    }



}
