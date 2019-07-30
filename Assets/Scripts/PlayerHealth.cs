using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private int health;
    [SerializeField] int healthDecrease = 1;
    [SerializeField] Text healthText;
    [SerializeField] AudioClip reachedGoalSFX;
    private static PlayerHealth instance;

    public delegate void onDeath();
    public static event onDeath playerDeath;

    public delegate void onHealtUpdate();
    public static event onHealtUpdate updatedUITowerHealth;

    public static PlayerHealth _Instance
    {
        get 
        {
            if (instance == null)
            {
                return new PlayerHealth();
            }
            else
                return instance;
        }
    }

    public int Health
    {
        get { return health; }
    }

    void Awake()
    {
        instance = this;
    }


    void Start()
    {
        health = 40;
        updatedUITowerHealth();
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered");
        GetComponent<AudioSource>().PlayOneShot(reachedGoalSFX);
        health -= healthDecrease;
        updatedUITowerHealth();

        if (health <= 0)
            playerDeath();

    }
}
