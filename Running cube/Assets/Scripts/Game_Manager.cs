using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
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

    //public Settings_Menu settingsMenu;
    [SerializeField] private Slider menuMusicSlider;
    [SerializeField] private Slider gameMusicSlider;
    [SerializeField] private Slider soundEffectsSlider;

    //Controlls the SETTINGS to input if you want to use joystick or slider
    public static bool isUsingJoystick = true;
    public Toggle sliderToggle;
    public Toggle joystickToggle;

    private Scene scene;
    public static PlayerCharacter[] characters = new PlayerCharacter[]{};
    public static PlayerCharacter characterEquipped;

    void Start()
    {
        scene = SceneManager.GetActiveScene();
        LoadGame();
        canvas = FindObjectOfType<Canvas>();

        if (scene.name != "Menu" && scene.name != "EndingScene" && scene.name != "Shop")
        {
            Debug.Log("INTRU IN IF");
            if (isUsingJoystick)
            {
                canvas.transform.Find("Fixed Joystick").gameObject.SetActive(true);
                canvas.transform.Find("Slider").gameObject.SetActive(false);
            }
            else
            {
                canvas.transform.Find("Fixed Joystick").gameObject.SetActive(false);
                canvas.transform.Find("Slider").gameObject.SetActive(true);
            }
        }
    }

    public void IsUsingJoystick (bool usingJoystick)
    {
        isUsingJoystick = usingJoystick;
        sliderToggle.isOn =! usingJoystick;
        //Debug.Log(isUsingJoystick);
    }

    public void isUsingSlider (bool usingSlider)
    {
        isUsingJoystick =! usingSlider;
        joystickToggle.isOn =! usingSlider;
        //Debug.Log(isUsingJoystick);
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
            
            canvas.transform.Find("LevelComplete").gameObject.SetActive(true);
        }
    }

    public static void BackToMenu ()
    {
        Pause_Game.GameIsPaused = false;
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Pause_Game.GameIsPaused = false;
        Time.timeScale = 1f;
        Score.score = 0;
    }

    public void SaveGame()
    {
        SaveSystem.SaveGame(this, FindObjectOfType<AudioManager>());
        Debug.Log("Saved level " + currentLvl + " fishes " + totalFishCollected + "Joystick: " + isUsingJoystick);
    }

    public void LoadGame()
    {
        if (scene.name == "Menu")
        {
            PlayerData data = SaveSystem.LoadGame();

            totalFishCollected = data.fishCollectible;
            currentLvl = data.currentLvl;
            isUsingJoystick = data.isUsingJoystick;

            //joystickToggle.isOn = data.isUsingJoystick;
            //sliderToggle.isOn = !data.isUsingJoystick;

            Debug.Log("Loaded level " + currentLvl + " fishes " + totalFishCollected + "joystick" + isUsingJoystick);

            menuMusicSlider.value = data.m_SavedVolume;
            gameMusicSlider.value = data.g_SavedVolume;
            soundEffectsSlider.value = data.s_SavedVolume;

            GameObject[] gameCharacters = GameObject.FindGameObjectsWithTag("Player");
            Debug.Log("Game characters: " + gameCharacters.Length);
            if (data.characters == null || data.characters.Length == 0) {
                Debug.Log("Data characters are null or empty");
                foreach(GameObject gameObject in gameCharacters) {
                    Debug.Log("Character name: " + gameObject.name);
                    Debug.Log("Character scene: " + gameObject.scene.name);
                    // gameObject.SetActive(gameCharacters.First() == gameObject);
                    if(gameObject.scene.name == "Menu") {
                        Debug.Log("Character scene is Menu");
                        PlayerCharacter playerCharacter = gameObject.GetComponent<PlayerCharacter>();
                        playerCharacter.equipped = gameCharacters.First() == gameObject;
                        characters.Append(playerCharacter);
                    }                   
                }
            } else {
                Debug.Log("Data characters not null or empty");
                characters = data.characters;
                characterEquipped = characters.Where(c => c.equipped).First();

            }
            
            Debug.Log("game manager characters after init: " + characters.Length);

            Debug.Log("Loaded menu: " + data.m_SavedVolume + "game " + data.g_SavedVolume + "sound " + data.s_SavedVolume);
        
        }
    } 
}
