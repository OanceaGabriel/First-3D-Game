using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public Transform player;
    public TextMeshProUGUI scoreTxt;

    public static int score = 0;
    void Update()
    {
        scoreTxt.text = score.ToString();
    }
}
