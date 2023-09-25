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
                transform.Translate(-2, 0, 0);
            }
            else if(startTouchPos.x > endTouchPos.x)
            {
                transform.Translate(2, 0, 0);
            }
        }
        currentCharacter = (-(this.transform.position.x) / 2);
        //Debug.Log(currentCharacter);
    }

    private void FixedUpdate()
    {
        if (transform.position.x < 0)
        {
            Debug.Log("Start");
            transform.transform.position = Vector3.zero;
        }
        else if (transform.position.x > characterIndex*2-2)
        {
            Debug.Log("End");
            transform.transform.position = new Vector3(characterIndex*2 -2, 0, 0);
        }
    }
}
