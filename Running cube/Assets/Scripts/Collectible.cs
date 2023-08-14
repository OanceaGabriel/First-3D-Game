using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{

    [SerializeField] private int gemScore = 20;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Score.score += gemScore;
            Destroy(gameObject);
        }
    }
}
