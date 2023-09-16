using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Character_Controller_Phone: MonoBehaviour
{
    [Header("Moving Parameters:")]
    [SerializeField] private float fw_Speed = 2000f;
    [SerializeField] private float side_Speed = 50f;
    [SerializeField] private float jump_Force;

    [Header("Allows jumping")]
    [Range(0f, 0.3f)][SerializeField] private float raycastDistance = 0.1f; //The length of the ray checking if the player is grounded
    [SerializeField] private float swipeTreshhold = 300f; //Swipe more than this to jump 
    [SerializeField] private LayerMask groundLayer; //you shoukd only jump from what is defined as beying Ground

    [Header("Jump Debuging")]
    [SerializeField] private bool isGrounded; //Is the player on the ground
    [SerializeField] private bool pressSpace; //has the Jump comand been inputed

    [SerializeField] private Animator animator;

    private float sideDirection = 0f; // Changes the direction in which the player moves

    [Header("Assign to enable movement")]
    [SerializeField] private Transform GroundCheck; //Object from where the ray is casted towards the ground to check if player is grounded
    [SerializeField] private Slider movementSlider; //Slider that moves player sideways
    [SerializeField] private Joystick joystick; //Joystick that moves the player sideways


    //Used to check for swiping in order to allow jump
    private Vector2 startTouchPos;
    private Vector2 endTouchPos;

    private int touchCount = 0; //if you have your had on the slider or joystick the second touch will be used for swiping, if you don't the first one will
    //public int controller = 0; //0 for slider or 1 for joystick
    public void Move() //Metoda ce permite miscarea caracterului folosind slider-ul
    {
        //This moves the player forward
        GetComponent<Rigidbody>().AddForce(0, 0, fw_Speed * Time.deltaTime);

        //This moves the character sideways by using the side_Speed and the direction specified in the player movement script
        GetComponent<Rigidbody>().AddForce(side_Speed * sideDirection * Time.deltaTime, 0, 0, ForceMode.VelocityChange);

        //Jumps if the conditions are met
        if (pressSpace == true && isGrounded == true)
        {
            Debug.Log("Jump!");
            GetComponent<Rigidbody>().AddForce(0 ,jump_Force*Time.deltaTime, 0, ForceMode.VelocityChange);
            pressSpace = false;
            
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Game_Manager.isUsingJoystick == true)
        {
            //Debug.Log("USING JOYSTICK");
            sideDirection = joystick.Horizontal;
        }
        isGrounded = Physics.Raycast(GroundCheck.position, Vector3.down, raycastDistance, groundLayer); //launches the ray to check if player is grounded
        animator.SetBool("isGrounded", isGrounded);
        //Checks if you have your finger on the slider or joystick already
        if (Input.touchCount  == 1)
        {
            touchCount = 0;
        }
        else
        {
            touchCount = 1;
        }
        
        //Checking for swiping up to allow for JUMP
       if (Input.touchCount > 0 && Input.GetTouch(touchCount).phase == TouchPhase.Began)
        {
            startTouchPos = Input.GetTouch(touchCount).position;
        }
       if (Input.touchCount >0 && Input.GetTouch(touchCount).phase == TouchPhase.Ended)
        {
            endTouchPos = Input.GetTouch(touchCount).position;
       
            if (startTouchPos.y < endTouchPos.y && endTouchPos.y - startTouchPos.y > swipeTreshhold)
            {  
               pressSpace = true;
               animator.SetBool("isJumping", true);
            }
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void OnCollisionEnter(Collision ground)
    {
        if (ground.gameObject.CompareTag("Ground"))
        {
            animator.SetBool("isJumping", false);
            animator.SetBool("isGrounded", true);
        }
    }

    public void SidewaysMovement (float value)
    {
        sideDirection = value;
        Debug.Log(sideDirection);
    }

   
}
