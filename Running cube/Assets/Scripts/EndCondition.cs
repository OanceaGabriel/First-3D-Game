using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndCondition : MonoBehaviour
{
    private bool lost = false;
    private GameObject[] movingObs;
    public Transform Player;
    
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
                FindObjectOfType<Game_Manager>().CompleteLevel();
                Invoke("NextLevel", 3f);
            }
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Obstacle") || collision.collider.gameObject.CompareTag("MovingObstacle"))
        {
            FindObjectOfType<AudioManager>().Stop("InGameMusic");
            //FindObjectOfType<AudioManager>().Play("Death");
            lost = true;
            GetComponent<Character_Controller_PC>().enabled = false;
            GetComponent<Character_Controller_Phone>().enabled = false;
            GetComponent<Character_Controller_Joystick>().enabled = false;
            FindObjectOfType<Game_Manager>().GameOver();

            foreach (GameObject obstacle in movingObs)
            {
                Rotate rotateScript = obstacle.GetComponent<Rotate>();
                MoveSideways moveSideways = obstacle.GetComponent<MoveSideways>();
                rotateScript.enabled = false;
                moveSideways.enabled = false;
            }
        }
    }
    private void Update()
    {
        if (transform.position.y < -1)
        {
            FindObjectOfType<Game_Manager>().GameOver();
        }
    }
}
