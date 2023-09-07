using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game_Manager : MonoBehaviour
{
    bool gameHasEnded = false;
    public float restartDelay = 1f;
    public static Game_Manager instance;
    private Canvas canvas;

    //Variables that track player progress
    public int totalFishCollected = 0;
    public static int currentLvl = 1;

    public Settings_Menu settingsMenu;
    public Slider menuMusicSlider;

    private void Start()
    {
        //LoadGame();
    }

    
    public void GameOver()
    {
        if (gameHasEnded == false)
        {
            FindObjectOfType<AudioManager>().Play("Death");
            gameHasEnded = true;
            Invoke("Restart", restartDelay);
        }
    }

    public static void LoadLevelSelector()
    {
        SceneManager.LoadScene("LevelSelection");
        Time.timeScale = 1f;
        Pause_Game.GameIsPaused = false;
    }

    public void CompleteLevel()
    {
        FindObjectOfType<AudioManager>().Stop("InGameMusic");
        FindObjectOfType<AudioManager>().Play("LevelComplete");
        currentLvl += 1;
        totalFishCollected += Score.score;
        SaveGame();
        if (FindObjectOfType<Canvas>().CompareTag("LevelComplete"))
        {
            canvas = FindObjectOfType<Canvas>();
            canvas.transform.Find("LevelComplete").gameObject.SetActive(true);
        }
    }

    public static void BackToMenu ()
    {
        Pause_Game.GameIsPaused = false;
        SceneManager.LoadScene(0);
    }

    public static void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Pause_Game.GameIsPaused = false;
        Time.timeScale = 1f;
        Score.score = 0;
    }

    public void SaveGame()
    {
        SaveSystem.SaveGame(this, settingsMenu);
        Debug.Log("Saved level " + currentLvl + " fishes " + totalFishCollected);
    }

    public void LoadGame()
    {
        PlayerData data = SaveSystem.LoadGame();

        totalFishCollected = data.fishCollectible;
        currentLvl = data.currentLvl;
        Debug.Log("Loaded level " + currentLvl + " fishes " + totalFishCollected);

        //if (settingsMenu != null)
        //{
            //settingsMenu.menuMusicMixer.SetFloat("MenuMusic", data.m_SavedVolume);
            //settingsMenu.gameMusicMixer.SetFloat("GameMusic", data.g_SavedVolume);
            //settingsMenu.soundEffectsMixer.SetFloat("Effects", data.s_SavedVolume);
        //}
        if (menuMusicSlider != null) 
        {
            menuMusicSlider.value = data.m_SavedVolume;
            Debug.Log("Loaded volume: " + data.m_SavedVolume);
        }
       
        
    }

    
}
