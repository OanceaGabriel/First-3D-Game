using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause_Game : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool GameIsPaused = false;
    public GameObject pauseMenu;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
                pauseMenu.SetActive(false);
            }
            else
            {
                Pause();
                pauseMenu.SetActive(true);
            }
        }
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
        pauseMenu.SetActive(false);
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
