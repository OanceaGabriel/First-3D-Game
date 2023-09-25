using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{

    [SerializeField] public int fishScore = 1;
     
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().Play("Collectible");
            Score.score += fishScore; //Fir displaying it on the current level
            Destroy(gameObject);
        }
    }
}
