using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{


    [SerializeField] Transform objectToPan;
    [SerializeField] float attackRange = 30f;
    [SerializeField] ParticleSystem projectilParticle;


    Transform targetEnemy;
    
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

        if (targetEnemy != null)
        {
            float distanceToEnemy = Vector3.Distance(targetEnemy.transform.position, gameObject.transform.position);
            //Debug.Log("distance: "+ distance);

            if (distanceToEnemy <= attackRange)
                Shoot(true);
            else
                Shoot(false);

        }
    }


    void Shoot(bool isActive)
    {
        //if (isActive)
        //    Debug.Log("----->>>> tower" + gameObject.name + " is shooting at distance: " + distanceToEnemy);
        //else
            //Debug.Log("tower" + gameObject.name + " is NOT shooting at distance: " + distanceToEnemy);

        var emissionModule = projectilParticle.emission;
        emissionModule.enabled = isActive;

    }
}
