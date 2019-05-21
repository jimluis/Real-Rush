using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] int health = 20;
    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] ParticleSystem goalParticlePrefab;

    void OnParticleCollision(GameObject other)
    {
        if (health == 0)
        {
            DestroyEnemy();
        }

        else
        { 
            health--;
            hitParticlePrefab.Play();
        }


    }

    public void DestroyEnemy()
    {
        var vfx = Instantiate(goalParticlePrefab, transform.position, Quaternion.identity);
        vfx.Play();
        float destroyDelay = vfx.main.duration;
        print("destroyDelay: " + destroyDelay);

        Destroy(vfx.gameObject, destroyDelay);
        Destroy(gameObject);
    }
}
