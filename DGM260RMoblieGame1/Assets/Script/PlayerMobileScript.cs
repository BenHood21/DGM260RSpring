using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMobileScript : MonoBehaviour
{
  public float playerSpeed;
  public Joystick joystick;
  public float gravity = -9.81f;
  public Transform groundCheck;
  public float groundDistance = 0.4f;
  public LayerMask groundMask;
  public bool isGround;
  public CharacterController controller;
 
  private Animator anim;
  private float horizontalMove = 1f;
  private float verticalMove = 1f;
  private Vector3 playerDirection;
  private Vector3 velocity;
    
  void Start()
  {
    anim = GetComponent<Animator>();
  }

  void Update()

  {
    Debug.Log(joystick.Direction);
    

    float x = Input.GetAxis("Horizontal");
    float z = Input.GetAxis("Vertical");

    Vector3 move = transform.right * x + transform.forward * z;
    controller.Move(move * playerSpeed * Time.deltaTime);
    velocity.y += gravity * Time.deltaTime;
    controller.Move(velocity * Time.deltaTime);

    if (playerDirection.magnitude >= .1f)
    {
      float targetAngle = Mathf.Atan2(playerDirection.x, playerDirection.y) * Mathf.Rad2Deg;
      transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

      controller.Move(playerDirection * playerSpeed * Time.deltaTime);
    }
    

    if (joystick.Vertical >= .2)
    {
      verticalMove = playerSpeed;
      anim.SetBool("Is Walking",true);
      Debug.Log("Front Movement");
    }
    if (joystick.Vertical <= -.2)
    {
      verticalMove = -playerSpeed;
      anim.SetBool("Is Walking",true);
      Debug.Log("Back Movement");
    }
    if (joystick.Horizontal >= .2)
    {
      horizontalMove = playerSpeed;
      anim.SetBool("Is Walking",true);
      Debug.Log("Right Movement");
    }
    else if (joystick.Horizontal <= -.2)
    {
      horizontalMove = -playerSpeed;
      anim.SetBool("Is Walking",true);
      Debug.Log("Left Movement");
    }
    else
    {
      horizontalMove = 0f;
      verticalMove = 0f;
      anim.SetBool("Is Walking",false);
    }

    playerDirection = new Vector3(horizontalMove, 0, verticalMove).normalized;
  }

  void FixedUpdate()
  {
    


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

 

