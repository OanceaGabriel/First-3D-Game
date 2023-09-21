using UnityEngine;
using UnityEngine.SceneManagement;

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

        AudioManager.Instance.Play("InGameMusic");
        AudioManager.Instance.Stop("Pause");
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        GameIsPaused = true;
        AudioManager.Instance.Stop("InGameMusic");
        AudioManager.Instance.Play("Pause");
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
