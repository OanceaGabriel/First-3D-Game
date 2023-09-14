using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    //public Transform playerPos;
    //public Vector3 cameraOffset;

    //void Update()
    //{
    //  transform.position = playerPos.position + cameraOffset;
    //}
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
            else
            {
                Debug.LogWarning("There is no active player in this scene");
            }
        }
    }
    void Update()
    {
        transform.position = currentPlayer.gameObject.transform.position - Offset;
    }
}
