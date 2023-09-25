using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitGame : MonoBehaviour
{
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit game!");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
