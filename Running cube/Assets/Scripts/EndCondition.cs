using UnityEngine;
using UnityEngine.SceneManagement;

public class EndCondition : MonoBehaviour
{
    private bool lost = false;
    private GameObject[] movingObs;
    //public Transform Player;
    
    public void Start()
    {
        movingObs = GameObject.FindGameObjectsWithTag("MovingObstacle");
    }
    void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Score.score = 0;
    }

    void OnTriggerEnter(Collider lvlEnded)
    {
        if (!lost)
        {
            if (lvlEnded.gameObject.CompareTag("LvlComplete"))
            {
                Game_Manager.Instance.CompleteLevel();
                Invoke(nameof(NextLevel), 3f);
            }
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Obstacle"))
        {
            AudioManager.Instance.Stop("InGameMusic");
            AudioManager.Instance.Play("Death");
            lost = true;
            GetComponent<Character_Controller_Phone>().enabled = false;
            Game_Manager.Instance.GameOver();
        }
    }
    private void Update()
    {
        if (transform.position.y < -1)
        {
            Game_Manager.Instance.GameOver();
        }
    }
}
