using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] int health = 20;
    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] ParticleSystem deathParticlePrefab;

    void OnParticleCollision(GameObject other)
    {
        if (health == 0)
        {
            var vfx = Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
            vfx.Play();
           // deathParticlePrefab.Play();
            Destroy(gameObject);
        }

        else
        { 
            health--;
            hitParticlePrefab.Play();
        }

        print("Enemy Hit - Health: ");
    }

}
