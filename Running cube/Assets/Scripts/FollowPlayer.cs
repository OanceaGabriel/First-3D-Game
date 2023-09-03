using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{


    [SerializeField] private Transform Player;
    [SerializeField] private Vector3 Offset;

    void Update()
    {
        transform.position = Player.position - Offset; 
    }

    
}
