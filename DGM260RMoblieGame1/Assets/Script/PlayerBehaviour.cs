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
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float playerSpeed;
    public Joystick joystick;
    public bool isGround;
    
    private float horizontalMove = 5f;
    private Vector3 velocity;
    private Rigidbody rb;
    private Vector2 playerDirection;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Youtube Tutorial: TOUCH CONTROLS in Unity! by Brackeys
        if (joystick.Horizontal >= .2f)
        {
            horizontalMove = playerSpeed;
        }
        else if (joystick.Horizontal <= -.2f)
        {
            horizontalMove = -playerSpeed;
        }
        else
        {
            horizontalMove = 0f;
        }
       
        playerDirection = new Vector3(horizontalMove,0,0).normalized;
        
        
        
        // Movement Controls and detection
        isGround = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        velocity.y += gravity * Time.deltaTime;

        if (isGround && velocity.y < 0)
        {
            velocity.y = -2f;
            Debug.Log("On Ground");
            
        }

        //Computer Controls for Testing
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGround)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }
        
        controller.Move(velocity * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        //Moblie touchmovement
        rb.velocity = new Vector3(playerDirection.x * playerSpeed, 0, 0);
    }
}
