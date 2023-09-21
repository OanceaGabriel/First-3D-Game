using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShopControlls : MonoBehaviour
{

    private int touchCount = 0;
    private float swipeTreshold = 300f;

    private Vector2 startTouchPos;
    private Vector2 endTouchPos;

    // Start is called before the first frame update
    public float currentCharacter;
    public int characterIndex;

    void Start()
    {
        characterIndex = this.transform.childCount;
        Debug.Log("caractere: " + characterIndex);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(touchCount).phase == TouchPhase.Began)
        {
            startTouchPos = Input.GetTouch(touchCount).position;
        }
        if (Input.touchCount > 0 && Input.GetTouch(touchCount).phase == TouchPhase.Ended)
        {
            endTouchPos = Input.GetTouch(touchCount).position;

            if (startTouchPos.x < endTouchPos.x)
            {
                this.transform.Translate(2, 0, 0);
                
            }
            else
            {
                this.transform.Translate(-2, 0, 0);
                
            }
        }
        if (this.transform.position.x == characterIndex * 2 + 2)
        {
            this.transform.Translate(0, 0, 0);
        }
        else if (this.transform.position.x == -2)
        {
            this.transform.Translate(characterIndex * 2 - 2, 0, 0);
        }

        currentCharacter = ((this.transform.position.x) / 2);
        //Debug.Log(currentCharacter);

    }
}