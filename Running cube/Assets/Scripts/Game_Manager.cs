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
    public static PlayerCharacterSerializable[] characters = new PlayerCharacterSerializable[]{};
    public static PlayerCharacterSerializable characterEquipped;
    public static AudioManager audioManager;

    void Start()
    {
        scene = SceneManager.GetActiveScene();
        audioManager = FindObjectOfType<AudioManager>();
        LoadGame();
        canvas = FindObjectOfType<Canvas>();

        if (scene.name != "Menu" && scene.name != "EndingScene" && scene.name != "Shop")
        {
            Debug.Log("INTRU IN IF");
            canvas.transform.Find("Fixed Joystick").gameObject.SetActive(isUsingJoystick);
            canvas.transform.Find("Slider").gameObject.SetActive(!isUsingJoystick);
        }
    }

    public void IsUsingJoystick (bool usingJoystick)
    {
        isUsingJoystick = usingJoystick;
        sliderToggle.isOn = !usingJoystick;
    }

    public void isUsingSlider (bool usingSlider)
    {
        isUsingJoystick = !usingSlider;
        joystickToggle.isOn = !usingSlider;
    }

    
    public void GameOver()
    {
        if (gameHasEnded == false)
        {
            audioManager.Play("Death");
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
        audioManager.Stop("InGameMusic");
        audioManager.Play("LevelComplete");
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
        SaveSystem.SaveGame(this, audioManager);
        Debug.Log("Saved level " + currentLvl + " fishes " + totalFishCollected + "Joystick: " + isUsingJoystick);
    }

    public void LoadGame()
    {
        if (scene.name == "Menu")
        {
            PlayerData data = SaveSystem.LoadGame(this, audioManager);
            Debug.Log("Loaded data: " + data.characters);

            totalFishCollected = data.fishCollectible;
            currentLvl = data.currentLvl;
            isUsingJoystick = data.isUsingJoystick;

            Debug.Log("Loaded level " + currentLvl + " fishes " + totalFishCollected + "joystick" + isUsingJoystick);

            menuMusicSlider.value = data.m_SavedVolume;
            gameMusicSlider.value = data.g_SavedVolume;
            soundEffectsSlider.value = data.s_SavedVolume;

            GameObject[] gameCharacters = GameObject.FindGameObjectsWithTag("Player");
            if (data.characters == null || data.characters.Length == 0) {
                Debug.Log("Data characters null or empty");
                foreach(GameObject gameObject in gameCharacters) {
                    PlayerCharacter playerCharacter = gameObject.GetComponent<PlayerCharacter>();
                    PlayerCharacterSerializable serializable = new(playerCharacter.value, 
                        playerCharacter.bought, gameObject.name == "Pudu", playerCharacter.characterName
                    );
                    characters = characters.Append(serializable).ToArray();                   
                }
            } else {
                Debug.Log("Data characters not null or empty");
                characters = data.characters;
                characterEquipped = characters.Where(c => c.Equipped).First();

            }
         
            Debug.Log("game manager characters after init: " + characters.Length);

            Debug.Log("Loaded menu: " + data.m_SavedVolume + "game " + data.g_SavedVolume + "sound " + data.s_SavedVolume);
        
        }
    } 
}
