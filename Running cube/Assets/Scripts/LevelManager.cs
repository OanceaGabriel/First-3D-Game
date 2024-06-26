using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] int levelIndex;
    public TextMeshProUGUI buttonText;

    private void Start()
    {
        buttonText.text = "Level " + levelIndex.ToString();
    }

    public void LevelSelector()
    {
        SceneManager.LoadScene(levelIndex);
    }
}
