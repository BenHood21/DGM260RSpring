using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobilePlayerBehaviour: MonoBehaviour
{
  public float maxPlayerSpeed;
  public Joystick joystick;
  public float gravity = -9.81f;
  public Transform groundCheck;
  public float groundDistance = 0.4f;
  public LayerMask groundMask;
  public bool isGround;
  public CharacterController controller;
  private float magnitude;
  
  private Animator anim;
  private float horizontalMove = 1f;
  private float verticalMove = 1f;
  private Vector3 playerDirection;
  private Vector3 velocity;
  private Vector2 directionVector = new Vector2(0,0);
  private float playerSpeed = 0f;
    
  void Start()
  {
    anim = GetComponent<Animator>();
  }

  void Update()

  {
    //  Debug.Log(joystick.Direction);
    float targetAngle = Mathf.Atan2(joystick.Direction.x, joystick.Direction.y) * Mathf.Rad2Deg;
    //Debug.Log(targetAngle);
    transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);
    directionVector = new Vector2(joystick.Horizontal,joystick.Vertical);
    magnitude = directionVector.magnitude;
    Debug.Log(magnitude);
    playerSpeed = Mathf.Lerp(0f, maxPlayerSpeed, Mathf.InverseLerp(0,1,magnitude));
    //Debug.Log(playerSpeed);
    transform.position += transform.forward * playerSpeed * Time.deltaTime;
    //Debug.Log(joystick.DeadZone);

    if (magnitude > .1)
    {
      anim.SetBool("Walking_Bool",true);
      Debug.Log("Walking with Weapon");
    }

    if (magnitude < .1)
    {
      anim.SetBool("Walking_Bool",false);

    }
    
  }
} 

 

