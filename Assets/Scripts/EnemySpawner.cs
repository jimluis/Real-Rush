using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Range(0.1f, 120f)]
    [SerializeField] float secondsBetweenSpawns = 0.5f;
    [SerializeField] EnemyMovement enemyMovement;
    [SerializeField] Transform enemyParentTransform;
    void Start()
    {
        StartCoroutine(Spawner());
    }

    IEnumerator Spawner()
    {
        while(true)
        {
            var newEnemy = Instantiate(enemyMovement, transform.position, Quaternion.identity);
            newEnemy.transform.parent = enemyParentTransform;
            Debug.Log("Spawing");
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
