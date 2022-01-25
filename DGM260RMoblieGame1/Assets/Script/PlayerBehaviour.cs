using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UIElements;

public class PlayerBehaviour : MonoBehaviour
{
    //public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float playerSpeed;
    public Joystick joystick;
    public bool isGround;
    public CharacterController controller;
    
    private float sidetoSideMove = 5f;
    private float frontBackMove = 5f;
    private Vector3 velocity;

    private void Start()
    {
       
    }

    void Update()
    {
        // Youtube Tutorial: First Person Movement in Unity by Brackeys

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
        
        // Youtube Tutorial: TOUCH CONTROLS in Unity! by Brackeys
        
        // Side to side movement
        if (joystick.Horizontal >= .2f)
        { 
            sidetoSideMove = playerSpeed;
            Debug.Log("Right Movement");
        }
        else if (joystick.Horizontal <= -.2f)
        {
            sidetoSideMove = -playerSpeed;
            Debug.Log("Left Movement");
        }
        else
        {
            sidetoSideMove = 0f;
        }
        
        if (joystick.Vertical >= .2f)
        {
            frontBackMove = playerSpeed;
            Debug.Log("Front Movement");
        }
        else if (joystick.Vertical <= -.2f)
        {
            frontBackMove = -playerSpeed;
            Debug.Log("Back Movement");
        }
        else
        {
            frontBackMove = 0f;
        }
        
        
        
        // Movement Controls and detection
       isGround = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
       velocity.y += gravity * Time.deltaTime;

        if (isGround && velocity.y < 0)
        {
            velocity.y = -2f;
            Debug.Log("On Ground");
            
        }

        if (Input.GetButtonDown("Jump") && isGround)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }
        
    }
}
