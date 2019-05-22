using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int health = 10;
    [SerializeField] int healthDecrease = 1;
    [SerializeField] Text healthText;
    [SerializeField] AudioClip reachedGoalSFX;

    void Start()
    {
        healthText.text = health.ToString();
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered");
        GetComponent<AudioSource>().PlayOneShot(reachedGoalSFX);
        health -= healthDecrease;
        healthText.text = health.ToString();
    }
}
