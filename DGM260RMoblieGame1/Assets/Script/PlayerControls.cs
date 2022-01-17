using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    private Vector3 velocity;
    public bool isGround;

     void Update()
    {
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
}
