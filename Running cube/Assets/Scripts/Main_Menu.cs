using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
   public void StartGame()
    {
        
        SceneManager.LoadScene(FindObjectOfType<Game_Manager>().currentLvl);
    }
    public void QuitGame()
    {
        Debug.Log(FindObjectOfType<Game_Manager>().currentLvl);
        Debug.Log("QUIT GAME!");
        Application.Quit();
    }
}
