using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] int health = 20;

    void OnParticleCollision(GameObject other)
    {
        if (health == 0)
            Destroy(gameObject);
        else
            health--;

        print("Enemy Hit - Health: ");
    }

}
