using UnityEngine;

public class RoundPosition : MonoBehaviour
{
    private void Update()
    {
        if (transform != null)
        {
            // Aplica formatarea pentru poziție
            transform.position = RoundVector3(transform.position, 2);
            //transform.rotation = RoundQuaternion(transform.rotation, 2);
        }
    }

    // Funcție pentru rotunjirea unui Vector3 la un număr specific de zecimale
    Vector3 RoundVector3(Vector3 vector, int decimalPlaces)
    {
        return new Vector3(
            (float)System.Math.Round(vector.x, decimalPlaces),
            (float)System.Math.Round(vector.y, decimalPlaces),
            (float)System.Math.Round(vector.z, decimalPlaces)
        );
    }

    Quaternion RoundQuaternion(Quaternion quaternion, int decimalPlaces)
    {
        return new Quaternion(
            (float)System.Math.Round(quaternion.x, decimalPlaces),
            (float)System.Math.Round(quaternion.y, decimalPlaces),
            (float)System.Math.Round(quaternion.z, decimalPlaces),
            (float)System.Math.Round(quaternion.w, decimalPlaces)
        );
    }
}
