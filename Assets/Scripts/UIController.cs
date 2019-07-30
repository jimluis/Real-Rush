using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
public class UIController : MonoBehaviour
{

    // Start is called before the first frame update
    [SerializeField] GameObject WinPanel;
    [SerializeField] GameObject TimeOutPanel;
    [SerializeField] GameObject lostPanel;
    [SerializeField] Text timeOutScore;
    [SerializeField] Text gameOverScore;
    [SerializeField] Text winScore;
    [SerializeField] Text towerHealth;

    void OnEnable()
    {
        CountDownTimer.timeOut += DisplayTimeOutPanel;
        PlayerHealth.playerDeath += DisplayGameOverPanel;
        PlayerHealth.updatedUITowerHealth += updateMainTowerHealth;
    }

    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayTimeOutPanel()
    {
        TimeOutPanel.SetActive(true);
        Debug.Log("DisplayTimeOutPanel - PlayerHealth._Instance.Health.ToString(): " + PlayerHealth._Instance.Health.ToString());
        timeOutScore.text = PlayerHealth._Instance.Health.ToString();
    }

    public void DisplayGameOverPanel()
    {
        Debug.Log("DisplayGameOverPanel - PlayerHealth._Instance.Health.ToString(): " + PlayerHealth._Instance.Health.ToString());
        lostPanel.SetActive(true);
        gameOverScore.text = PlayerHealth._Instance.Health.ToString();
    }

    public void DisplayWinPanel()
    {
        Debug.Log("DisplayWinPanel - PlayerHealth._Instance.Health.ToString(): " + PlayerHealth._Instance.Health.ToString());
        WinPanel.SetActive(true);
        winScore.text = PlayerHealth._Instance.Health.ToString();
    }

    void updateMainTowerHealth()
    {
        towerHealth.text = PlayerHealth._Instance.Health.ToString();
    }

    void OnDisable()
    {
        CountDownTimer.timeOut -= DisplayTimeOutPanel;
        PlayerHealth.playerDeath -= DisplayGameOverPanel;
        PlayerHealth.updatedUITowerHealth -= updateMainTowerHealth;
    }
}
