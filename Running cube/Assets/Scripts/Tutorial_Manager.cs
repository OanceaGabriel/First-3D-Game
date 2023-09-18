using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial_Manager : MonoBehaviour
{
    [SerializeField] private GameObject backgroundPanel;
    [SerializeField] private GameObject introductionPanel;
    [SerializeField] private GameObject movementPanel;
    [SerializeField] private Canvas tutorialCanvas;

    private Image image;
    private Animator animator;

    private bool once = true;
    private bool onceTutorial2 = true;
    private bool onceTutorial3 = true;

    // Update is called once per frame

    private void Start()
    {
        image = backgroundPanel.GetComponent<Image>();
        animator = backgroundPanel.GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.touchCount > 0 && introductionPanel.gameObject.activeInHierarchy)
        {
            animator.SetBool("fade", false);
            backgroundPanel.transform.Find("Introduction").gameObject.SetActive(false);
            Time.timeScale = 1.0f;
            onceTutorial2 = false;
        }

        if (Input.touchCount > 0 && !onceTutorial2)
        {
            animator.SetBool("fade", false);
            animator.SetBool("tutorial2", false);
            image.enabled = false;
            Time.timeScale = 1f;
            onceTutorial3 = false;
            backgroundPanel.transform.Find("Movement").gameObject.SetActive(false);
        }

        if (Input.touchCount > 0 && !onceTutorial3)
        {
            animator.SetBool("fade", false);
            animator.SetBool("tutorial3", false);
            image.enabled = false;
            backgroundPanel.transform.Find("Movement").gameObject.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.name == "Tutorial_1" && once)
        {
            tutorialCanvas.gameObject.SetActive(true);
            animator.SetBool("tutorial1", true);
            Time.timeScale = 0f;
            once = false;
        }

        if (collider.name == "Tutorial_2" && !once)
        {
            backgroundPanel.transform.Find("Movement").gameObject.SetActive(true);
            animator.SetBool("fade", true);
            animator.SetBool("tutorial2", true);
            image.enabled = true;
            Time.timeScale = 0f;
            once = true;
        }

        if (collider.name == "Tutorial_3" && once)
        {
            backgroundPanel.transform.Find("Movement").gameObject.SetActive(true);
            image.enabled = true;
            animator.SetBool("fade", true);
            animator.SetBool("tutorial3", true);
            Time.timeScale = 0f;
            onceTutorial3 = false;
            once = false;
        }
        
    }
}
