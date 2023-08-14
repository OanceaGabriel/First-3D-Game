using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game_Manager : MonoBehaviour
{

    bool gameHasEnded = false;
    public float restartDelay = 1f;
    public GameObject completeLevelUI;
   public void GameOver ()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Invoke("Restart", restartDelay);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Pause_Game.GameIsPaused = false;
        Time.timeScale = 1f;
    }

    public void LoadLevelSelector()
    {
        SceneManager.LoadScene("LevelSelection");
        Time.timeScale = 1f;
        Pause_Game.GameIsPaused = false;
    }

    public void CompleteLevel()
    {
        completeLevelUI.SetActive(true);
    }

    
}
