using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{


    [SerializeField] Transform objectToPan;
    [SerializeField] float attackRange = 30f;
    [SerializeField] ParticleSystem projectilParticle;
    public Waypoint baseWaypoint;

    Transform targetEnemy;


    void OnEnable()
    {
        UIController.OnDestroyGameObj += OnDestroyTower;
    }

    void Start()
    {
        var emissionModule = FindObjectOfType<ParticleSystem>().emission;
        emissionModule.enabled = true;
    }
    // Update is called once per frame
    void Update()
    {
        SetTargetEnemy();

        if(targetEnemy)
        { 
            objectToPan.LookAt(targetEnemy);
            FireAtEnemy();
        }
        else
            Shoot(false);
    }

    void SetTargetEnemy()
    {
        var sceneEnemies = FindObjectsOfType<Enemy>();

        if (sceneEnemies.Length == 0)
            return;

        Transform closestEnemy = sceneEnemies[0].transform;

        foreach(Enemy testEnemy in sceneEnemies)
        {
            closestEnemy = GetClosest(closestEnemy, testEnemy.transform);
        }

        targetEnemy = closestEnemy;
    }

    private Transform GetClosest(Transform transformA, Transform transformB)
    {

        var distToA = Vector3.Distance(transform.position, transformA.position);
        var distToB = Vector3.Distance(transform.position, transformB.position);

        if (distToA < distToB)
            return transformA;

        return transformB;

    }

    private void FireAtEnemy()
    {

        Debug.Log("Tower.FireAtEnemy: " + EnemySpawner.stopSpawning);
        if (targetEnemy != null)
        {
            float distanceToEnemy = Vector3.Distance(targetEnemy.transform.position, gameObject.transform.position);

            if (distanceToEnemy <= attackRange)
                Shoot(true);
            else
                Shoot(false);

        }
    }


    void Shoot(bool isActive)
    {
        var emissionModule = projectilParticle.emission;
        emissionModule.enabled = isActive;

    }

    void OnDestroyTower()
    {
       Destroy(this.gameObject);
    }

    void OnDisable()
    {
        UIController.OnDestroyGameObj -= OnDestroyTower;
    }
}
