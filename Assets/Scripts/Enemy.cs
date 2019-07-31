using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] int health = 20;
    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] ParticleSystem goalParticlePrefab;
    [SerializeField] AudioClip enemyHitSFX;
    [SerializeField] AudioClip enemyDeathSFX;
    AudioSource myAudioSource;

    private void OnEnable()
    {
        UIController.OnDestroyGameObj += DestroyEnemy;
    }

    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }

    void OnParticleCollision(GameObject other)
    {
        if (health == 0)
        {
            Debug.Log("^Enemy.OnParticleCollision - health: " + health);
            DestroyEnemy();
        }

        else
        { 
            health--;
            myAudioSource.PlayOneShot(enemyHitSFX);
            hitParticlePrefab.Play();
        }


    }

    public void DestroyEnemy()
    {
        var vfx = Instantiate(goalParticlePrefab, transform.position, Quaternion.identity);
        vfx.Play();
        float destroyDelay = vfx.main.duration;
        Debug.Log(">>Enemy.destroyDelay: " + destroyDelay);
        myAudioSource.PlayOneShot(enemyDeathSFX);
        Destroy(vfx.gameObject, destroyDelay);
        Destroy(gameObject);
    }

    void OnDisable()
    {
        UIController.OnDestroyGameObj -= DestroyEnemy;
    }
}
