using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;
using UnityEditor;

public class Character_Controller_Phone: MonoBehaviour
{
    [Header("Moving Parameters:")]
    [SerializeField] private float fw_Speed = 2000f;
    [SerializeField] private float side_Speed = 50f;
    [SerializeField] private float jump_Force;

    [Header("Allows jumping")]
    [Range(0f, 0.3f)][SerializeField] private float raycastDistance = 0.1f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private bool isGrounded;
    [SerializeField] private bool pressSpace;

    [SerializeField] private Animator animator;

    private float tiltValue = 0f;

    [Header("Tilt tuning")]
    [SerializeField] private float tiltTreshold;

    [SerializeField] private Transform GroundCheck;

    private Gyroscope gyro;
    private Quaternion rotation;

    public void Start()
    {
        gyro = Input.gyro;
        gyro.enabled = true;

        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }
    public void Move() //Metoda ce permite miscarea caracterului
    {
        //This moves the player forward
        GetComponent<Rigidbody>().AddForce(0, 0, fw_Speed * Time.deltaTime);

        //This moves the character sideways by using the side_Speed and the direction specified in the player movement script
        GetComponent<Rigidbody>().AddForce(side_Speed * tiltValue * Time.deltaTime, 0, 0, ForceMode.VelocityChange);

        if (pressSpace == true && isGrounded == true)
        {
            //Debug.Log("Jump!");
            GetComponent<Rigidbody>().AddForce(0 ,jump_Force*Time.deltaTime, 0, ForceMode.VelocityChange);
        }
    }
    // Update is called once per frame


    void Update()
    {
        // Obține rotația telefonului într-un mod compatibil cu orientarea ecranului
        rotation = Quaternion.Euler(90, 90, 0) * gyro.attitude;

        float angle = rotation.eulerAngles.z;

        if (angle > 15 && angle < 180 - tiltTreshold)
        {
            tiltValue = 1; // Rotire spre dreapta
        }
        else if (angle > 180 + tiltTreshold && angle < 345)
        {
            tiltValue = -1; // Rotire spre stânga
        }
        else
        {
            tiltValue = 0; // Nu există rotație sau rotație mică
        }
        isGrounded = Physics.Raycast(GroundCheck.position, Vector3.down, raycastDistance, groundLayer);
        //Debug.Log(tiltValue);
        Debug.Log(angle);
        if (Input.touchCount >0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                pressSpace = true;
                animator.SetBool("Should_Jump", true);
            }
            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                pressSpace = false;
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
            animator.SetBool("Should_Jump", false);
        }
    }


}
