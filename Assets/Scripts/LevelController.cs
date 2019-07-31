using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class LevelController : MonoBehaviour
{

    public static bool isInstructionPanelDisplayed = false;
    List<EnemyMovement> enemyList = new List<EnemyMovement>();


    public void LoadNextLevel()
    {
        int currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
        int nextScene = currentScene + 1;

        if (currentScene == UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings)
            nextScene = 0;

        UnityEngine.SceneManagement.SceneManager.LoadScene(nextScene);
    }


    public void ReloadLevel()
    {
        int currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
        UnityEngine.SceneManagement.SceneManager.LoadScene(currentScene);
    }


}
