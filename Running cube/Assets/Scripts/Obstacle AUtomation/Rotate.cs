using UnityEngine;

public class Rotate : MonoBehaviour
{
    public Vector3 rotationSpeed; 
    void FixedUpdate()
    {
       transform.Rotate(rotationSpeed);
    }
}
