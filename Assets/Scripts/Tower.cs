using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToPan;
    [SerializeField] Transform targetEnemy;
  //  [SerializeField] ParticleSystem bullets;

    void Start()
    {
        var emissionModule = FindObjectOfType<ParticleSystem>().emission;
        emissionModule.enabled = true;
    }
    // Update is called once per frame
    void Update()
    {
        objectToPan.LookAt(targetEnemy);
    }
}
