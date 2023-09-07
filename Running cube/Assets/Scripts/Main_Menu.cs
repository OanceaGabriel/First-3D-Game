using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
   public void StartGame()
    {
        
        SceneManager.LoadScene(Game_Manager.currentLvl);
    }
    public void QuitGame()
    {
        Debug.Log(Game_Manager.currentLvl);
        Debug.Log("QUIT GAME!");
        Application.Quit();
    }
}
