using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSideways : MonoBehaviour
{
    [SerializeField] private Vector3 ObstacleSpeed;

    private void MovingObs()
    {
        GetComponent<Rigidbody>().AddForce(ObstacleSpeed, ForceMode.VelocityChange);
    }
    private void FixedUpdate()
    { 
        MovingObs();
    }

    private void OnTriggerEnter(Collider Obstacle)
    {
        if (Obstacle.gameObject.CompareTag("DirectionSwitch"))
        {
            ObstacleSpeed *= -1;
        }
    }
}
