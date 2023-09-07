using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleManager : MonoBehaviour
{
    [SerializeField] private Toggle joystickToggle;
    [SerializeField] private Toggle sliderToggle;

    // Start is called before the first frame update
    void Start()
    {
        if(Game_Manager.isUsingJoystick)
        {
            joystickToggle.isOn = true;
            sliderToggle.isOn = false;
        }
        else
        {
            joystickToggle.isOn = false;
            sliderToggle.isOn = true;
        }
    }

    
}
