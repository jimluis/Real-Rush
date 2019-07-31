using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
public class UIController : MonoBehaviour
{

    // Start is called before the first frame update
    public static bool isInstructionPanelDismissed = false;

    [SerializeField] GameObject WinPanel;
    [SerializeField] GameObject instructionPanel;
    [SerializeField] GameObject TimeOutPanel;
    [SerializeField] GameObject lostPanel;
    [SerializeField] Text timeOutScore;
    [SerializeField] Text gameOverScore;
    [SerializeField] Text winScore;
    [SerializeField] Text towerHealth;
    [SerializeField] Sprite muteImage;
    [SerializeField] Sprite playImage;
    [SerializeField] Button muteButton;

    public static Action OnDestroyGameObj;

    public delegate void StartSpawner();
    public static event StartSpawner initSpawner;


    public delegate void SoundController();
    public static event SoundController soundControl;

    void OnEnable()
    {
        CountDownTimer.timeOut += DisplayTimeOutPanel;
        PlayerHealth.playerDeath += DisplayGameOverPanel;
        PlayerHealth.updatedUITowerHealth += updateMainTowerHealth;
    }

    void Start()
    {
        Debug.Log("UIController.DisplayTimeOutPanel: " + isInstructionPanelDismissed);

        if (isInstructionPanelDismissed)
        {
            instructionPanel.SetActive(false);
            initSpawner();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayTimeOutPanel()
    {
        OnDestroyGameObj();
        TimeOutPanel.SetActive(true);
        Debug.Log("DisplayTimeOutPanel - PlayerHealth._Instance.Health.ToString(): " + PlayerHealth._Instance.Health.ToString());
        string txt;

        if (PlayerHealth._Instance.Health > 0)
            txt = "You saved the tower";
        else
            txt = "You've lost the tower";

        timeOutScore.text = txt;
        EnemySpawner.stopSpawning = false;
        isInstructionPanelDismissed = false;
    }

    public void DisplayGameOverPanel()
    {
        Debug.Log("DisplayGameOverPanel - PlayerHealth._Instance.Health.ToString(): " + PlayerHealth._Instance.Health.ToString());
        OnDestroyGameObj();
        lostPanel.SetActive(true);
        gameOverScore.text = "Score: "+PlayerHealth._Instance.Health.ToString();
        EnemySpawner.stopSpawning = false;
        isInstructionPanelDismissed = false;
    }

    public void DisplayWinPanel()
    {
        Debug.Log("DisplayWinPanel - PlayerHealth._Instance.Health.ToString(): " + PlayerHealth._Instance.Health.ToString());
        OnDestroyGameObj();
        WinPanel.SetActive(true);
        winScore.text = "Score: " + PlayerHealth._Instance.Health.ToString();
        EnemySpawner.stopSpawning = false;
        isInstructionPanelDismissed = false;
    }

    public void DismissInstructionPanelPanel()
    {
        instructionPanel.SetActive(false);
        isInstructionPanelDismissed = true;
        initSpawner();


    }


    void updateMainTowerHealth()
    {
        towerHealth.text = PlayerHealth._Instance.Health.ToString();
    }


    public void ToggleSoundImage()
    {
        Sprite image = muteButton.GetComponent<Image>().sprite;

        if (image.name == "Mute")
        {
            soundControl?.Invoke();
            muteButton.GetComponent<Image>().sprite = playImage;
        }
        else
        {
            soundControl?.Invoke();
            muteButton.GetComponent<Image>().sprite = muteImage;
        }
    }

    void OnDisable()
    {
        CountDownTimer.timeOut -= DisplayTimeOutPanel;
        PlayerHealth.playerDeath -= DisplayGameOverPanel;
        PlayerHealth.updatedUITowerHealth -= updateMainTowerHealth;
        isInstructionPanelDismissed = true;
    }

}
