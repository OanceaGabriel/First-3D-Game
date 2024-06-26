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
    public void GameOver()
    {
        if (gameHasEnded == false)
        {
            FindObjectOfType<AudioManager>().Play("Death");
            gameHasEnded = true;
            Invoke("Restart", restartDelay);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Pause_Game.GameIsPaused = false;
        Time.timeScale = 1f;
        Score.score = 0;
    }

    public void LoadLevelSelector()
    {
        SceneManager.LoadScene("LevelSelection");
        Time.timeScale = 1f;
        Pause_Game.GameIsPaused = false;
        Score.score = 0;
    }

    public void CompleteLevel()
    {
        FindObjectOfType<AudioManager>().Stop("InGameMusic");
        FindObjectOfType<AudioManager>().Play("LevelComplete");
        completeLevelUI.SetActive(true);
    }

    public void BackToMenu ()
    {
        Pause_Game.GameIsPaused = false;
        SceneManager.LoadScene(0);
        Score.score = 0;
    }

    
}
