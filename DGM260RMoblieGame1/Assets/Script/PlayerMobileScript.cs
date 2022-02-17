using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMobileScript : MonoBehaviour
{
  public float playerSpeed;
  public Joystick joystick;
  public float gravity = -9.81f;
  public float jumpHeight = 3f;
  public Transform groundCheck;
  public float groundDistance = 0.4f;
  public LayerMask groundMask;
  public bool isGround;
  
  private Animator anim;
  private float horizontalMove = 5f;
  private float verticalMove = 5f;
  public Rigidbody rb;
  private Vector3 playerDirection;
  private Vector3 velocity;
    
  void Start()
  {
    rb = GetComponent<Rigidbody>();
    anim = GetComponent<Animator>();
  }

  void Update()

  {
    // Youtube Tutorial: TOUCH CONTROLS in Unity! by Brackeys

    if (joystick.Vertical >= .2f)
    {
      verticalMove = playerSpeed;
      anim.SetBool("is Walking",true);
      Debug.Log("Front Movement");
    }
    if (joystick.Vertical <= -.2f)
    {
      verticalMove = -playerSpeed;
      anim.SetBool("is Walking",true);
      Debug.Log("Back Movement");
    }
    if (joystick.Horizontal >= .2f)
    {
      horizontalMove = playerSpeed;
      anim.SetBool("is Walking",true);
      Debug.Log("Right Movement");
    }
    else if (joystick.Horizontal <= -.2f)
    {
      horizontalMove = -playerSpeed;
      anim.SetBool("is Walking",true);
      Debug.Log("Left Movement");
    }
    else
    {
      horizontalMove = 0f;
      verticalMove = 0f;
      anim.SetBool("is Walking",false);
    }

    playerDirection = new Vector3(horizontalMove, 0, verticalMove).normalized;
  }

  void FixedUpdate()
  {

    rb.velocity = new Vector3(playerDirection.x * playerSpeed, 0, playerDirection.z);


    // Movement Controls and detection
    isGround = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
    velocity.y += gravity * Time.deltaTime;

    if (isGround && velocity.y < 0)
    {
      velocity.y = -2f;
      Debug.Log("On Ground");
    }
  }
} 

 

