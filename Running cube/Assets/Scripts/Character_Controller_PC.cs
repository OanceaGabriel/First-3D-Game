using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;
using UnityEditor;

public class Character_Controller_PC: MonoBehaviour
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

        if (pressSpace == true && isGrounded == true)
        {
            Debug.Log("Jump!");
            GetComponent<Rigidbody>().AddForce(0 ,jump_Force*Time.deltaTime, 0, ForceMode.VelocityChange);

            FindObjectOfType<AudioManager>().Play("Jump");
        }
    }
    // Update is called once per frame


    void Update()
    {
        
        isGrounded = Physics.Raycast(GroundCheck.position, Vector3.down, raycastDistance, groundLayer);
        sideChange = Input.GetAxisRaw("Horizontal");

            if (Input.GetButtonDown("Jump"))
            {
                pressSpace = true;
                animator.SetBool("Should_Jump", true);
                return;
            }
        
            //else if (Input.GetButtonUp("Jump"))
           // {
             pressSpace = false;
            //}   
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
