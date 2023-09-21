using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] int levelIndex;
    public TextMeshProUGUI buttonText;

    private void Awake()
    {
        if(levelIndex > Game_Manager.currentLvl)
        {
            Debug.Log(this.name);
            this.gameObject.SetActive(false);
        }
    }
    private void Start()
    {
        buttonText.text = "Level " + levelIndex.ToString();
    }

    public void LevelSelector()
    {
        SceneManager.LoadScene(levelIndex);
    }
}
