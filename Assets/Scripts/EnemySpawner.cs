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
    [SerializeField] AudioClip spawnEnemiesSFX;

    public static bool stopSpawning = true;

    void OnEnable()
    {
        UIController.initSpawner += StartSpawner;
    }

    public void StartSpawner()
    {
        Debug.Log(">>> EnemySpawner.StartSpawner(): stopSpawning "+ stopSpawning);
        StartCoroutine(Spawner());
    }

    IEnumerator Spawner()
    {
        while(stopSpawning)
        { 
            Debug.Log(">>> Spawner EnemySpawner.StartSpawner()");

            var newEnemy = Instantiate(enemyMovement, transform.position, Quaternion.identity);
            GetComponent<AudioSource>().PlayOneShot(spawnEnemiesSFX);
            newEnemy.transform.parent = enemyParentTransform;

            Debug.Log("Spawing");
            yield return new WaitForSeconds(secondsBetweenSpawns);

        }
    }

    void OnDisable()
    {
        stopSpawning = true;
        UIController.initSpawner -= StartSpawner;
    }
}
