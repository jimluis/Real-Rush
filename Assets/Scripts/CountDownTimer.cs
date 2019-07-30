using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CountDownTimer : MonoBehaviour
{

    [SerializeField] float mainTimer;
    private float timer;
    public bool canCount = true;
    private bool doOnce = false;
    Text timerText;

    public  delegate void TimeOver();
    public static event TimeOver timeOut;

    // Start is called before the first frame update
    void Start()
    {
        timer = mainTimer;
        timerText = GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        if(timer >= 0.0f && canCount)
        {
            timer -= Time.deltaTime;
            timerText.text = timer.ToString("F");
        }
        else if(timer <= 0.0f && !doOnce) 
        {
            canCount = false;
            doOnce = true;
            timerText.text = "0.00";
            timer = 0.0f;
            timeOut();
        }
    }
}
