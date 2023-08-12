using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    public Transform playerPos;
    public Vector3 cameraOffset;
   
    void Update()
    {
        transform.position = playerPos.position + cameraOffset;
    }
}
