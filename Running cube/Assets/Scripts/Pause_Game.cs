using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause_Game : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenu;

    // Update is called once per frame
    void Update()
    {
       //if(Input.GetKeyDown(KeyCode.Escape))
       //{
           // if(GameIsPaused)
           // {
             //   Resume();
            //    pauseMenu.SetActive(false);
           // }
           // else
           // {
           //     Pause();
             //   pauseMenu.SetActive(true);
            //}
        //}
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
        pauseMenu.SetActive(false);

        FindObjectOfType<AudioManager>().Play("InGameMusic");
        FindObjectOfType<AudioManager>().Stop("Pause");
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        GameIsPaused = true;
        FindObjectOfType<AudioManager>().Stop("InGameMusic");
        FindObjectOfType<AudioManager>().Play("Pause");
    }

    public void LoadLevelSelector()
    {
        SceneManager.LoadScene("LevelSelection");
        Time.timeScale = 1f;
        GameIsPaused = false;
        //Score.score = 0;
    }

    public void TimeStep1()
    {
        Time.timeScale = 1f;
    }

    public void BackToMenu()
    {
        GameIsPaused = false;
        SceneManager.LoadScene("Menu");
        Score.score = 0;
    }

   
}
