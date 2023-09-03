using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slider_Manager : MonoBehaviour
{
    [SerializeField] private Slider movementslider;
    

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                movementslider.value = 0;
            }
        }
        
    }
}
