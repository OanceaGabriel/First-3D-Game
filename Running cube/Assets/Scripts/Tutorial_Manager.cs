using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Tutorial_Manager : MonoBehaviour
{
    [SerializeField] private GameObject backgroundPanel;
    [SerializeField] private GameObject introductionPanel;
    [SerializeField] private GameObject movementPanel;
    [SerializeField] private Canvas tutorialCanvas;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && tutorialCanvas.isActiveAndEnabled)
        {
            Time.timeScale = 1f;
            Debug.Log("touch");
            introductionPanel.gameObject.SetActive(false);
            backgroundPanel.GetComponent<Animator>().SetBool("enabled", false);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.name == "Tutorial_1")
        {
            tutorialCanvas.gameObject.SetActive(true);
            introductionPanel.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }

        if (collider.name =="Tutorial_2")
        {

        }
        
    }
}
