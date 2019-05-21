using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [Range(0.1f, 120f)]
    [SerializeField] float secondsBetweenSpawns = 0.5f;
    [SerializeField] EnemyMovement enemyMovement;
    [SerializeField] Transform enemyParentTransform;
    [SerializeField] Text spawnEnemies;
    int score; 

    void Start()
    {
        StartCoroutine(Spawner());
        spawnEnemies.text = score.ToString(); ;
    }

    IEnumerator Spawner()
    {
        while(true)
        {
            score++;
            spawnEnemies.text = score.ToString();

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
