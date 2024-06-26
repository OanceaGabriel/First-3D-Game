﻿using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;
using UnityEditor;
using UnityEngine.EventSystems;

public class Character_Controller_Joystick : MonoBehaviour
{
    [Header("Moving Parameters:")]
    //Viteza de inaintare
    [SerializeField] private float fw_Speed = 2000f;
    //Viteza de miscare stanga dreapta
    [SerializeField] private float side_Speed = 50f;
    //Forta de saritura
    [SerializeField] private float jump_Force;
    public bool test;

    [Header("Allows jumping")]
    [Range(0f, 0.3f)][SerializeField] private float raycastDistance = 0.1f; //Distanta la care se verifica daca jucatorul este la sol
    [SerializeField] private LayerMask groundLayer; //Masca care sorteaza pe ce ai aterizat
    [SerializeField] private LayerMask joysticLayer; //Masca care sorteaza apasarea pe joystick
    [SerializeField] private bool isGrounded; //esti la sol?
    [SerializeField] private bool pressSpace; //Ai apasat butonul de jump?

    [Header("Joystick")]
    public Joystick joystick;

    [SerializeField] private Animator animator;
    
    private float sideChange = 0f;

    [SerializeField] private Transform GroundCheck;

    public void Start()
    {
 
    }
    public void Move() //Metoda ce permite miscarea caracterului
    {
        //This moves the player forward
        GetComponent<Rigidbody>().AddForce(0, 0, fw_Speed * Time.deltaTime);

        //This moves the character sideways by using the side_Speed and the direction specified in the player movement script
        GetComponent<Rigidbody>().AddForce(side_Speed * sideChange * Time.deltaTime, 0, 0, ForceMode.VelocityChange);

        //Daca ai apasat butonul de JUMP si esti la sol poti sari din nou
        if (pressSpace == true && isGrounded == true)
        {
            //Debug.Log("Jump!");
            GetComponent<Rigidbody>().AddForce(0 ,jump_Force*Time.deltaTime, 0, ForceMode.VelocityChange);
        }
    }
   
    void Update()
    {
        //Lanseaza o raza care verifica daca ai aterizat pe sol modificand valoarea variabilei bool isGrounded
        isGrounded = Physics.Raycast(GroundCheck.position, Vector3.down, raycastDistance, groundLayer);
        Debug.Log(isGrounded);
        sideChange = joystick.Horizontal;
    
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = touch.position;
            if (touch.phase == TouchPhase.Began)
            {
                if (!IsPointerOverUIObject(touchPos))
                {
                    test = IsPointerOverUIObject(touchPos);
                    pressSpace = true;
                }
                animator.SetBool("Should_Jump", true);
            }
            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled || IsPointerOverUIObject(touchPos))
            {
                pressSpace = false;
            }
            
        }
    }

    private void FixedUpdate()
    {
        //Apeleaza functia de miscare
        Move();
    }

    private void OnCollisionEnter(Collision ground)
    {
        //Controleaza animatia de saritura
        if (ground.gameObject.CompareTag("Ground"))
        {
            animator.SetBool("Should_Jump", false);
        }
    }


    bool IsPointerOverUIObject(Vector2 touchPosition) //Verifica daca atingi pe joystick pentru a nu permite saritul in acest caz
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = touchPosition;

        // Verifica dacă există atingere cu elemente UI
        var results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);

        if(results.Count > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
            
    }

}
