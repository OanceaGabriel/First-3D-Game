using System;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private Vector3 Offset;

    private GameObject currentPlayer;
    private Array players;

    private void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");

        foreach (GameObject gameObject in players)
        {
            if (gameObject.activeInHierarchy == true)
            {
                currentPlayer = gameObject;
            }
        }
    }
    void Update()
    {
        transform.position = currentPlayer.transform.position - Offset;
    }

    
}
