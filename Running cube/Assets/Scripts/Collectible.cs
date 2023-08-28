using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{

    [SerializeField] private int gemScore = 1;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().Play("Collectible");
            Score.score += gemScore;
            Destroy(gameObject);
        }
    }
}
