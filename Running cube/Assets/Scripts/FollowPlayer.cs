using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    

    [SerializeField] private Transform Player;
    public Vector3 Offset;
   
    private void Start()
    {

    }
    void Update()
    {
        transform.position = Player.position - Offset;
    }
}
