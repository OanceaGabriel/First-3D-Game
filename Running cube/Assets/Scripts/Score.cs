using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Transform player;
    public TextMeshProUGUI scoreTxt;
    void Update()
    {
        scoreTxt.text = player.position.z.ToString("0");
    }
}
