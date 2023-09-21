using UnityEngine;

public class Collectible : MonoBehaviour
{

    public int fishScore = 1;
     
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AudioManager.Instance.Play("Collectible");
            Score.score += fishScore; //Fir displaying it on the current level
            Destroy(gameObject);
        }
    }
}
