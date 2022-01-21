using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupController : MonoBehaviour
{
// Script help from Dave / GameDevelopment on Youtube

    public MeleeWeapon meleeScript;
    public Rigidbody rb;
    public Collider coll;
    public Transform player, weaponContainer, camera;
    public float pickUpRange;
    public float dropForwardForce, dropUpwardForce;
    public bool equipped;
    public static bool slotFull;

    private void Update()
    {
        // Checking if player is in range and is pressing "E"
        Vector3 distanceToPlayer = player.position - transform.position;
        if (!equipped && distanceToPlayer.magnitude <= pickUpRange && Input.GetKeyDown(KeyCode.E)&& !slotFull) Pickup();
        
        // if equipped and pressing "Q" drop
        if (equipped && Input.GetKeyDown(KeyCode.Q)) Drop();

    }

    private void Pickup()
    {
        equipped = true;
        slotFull = true;
        
        // Make Rigidbody kinematic and BoxCollider a trigger
        rb.isKinematic = true;
        coll.isTrigger = true;
        
        //Enable script
        meleeScript.enabled = true;
    }

    private void Drop()
    {
        equipped = false;
        slotFull = false;
        
        // Make Rigidbody not kinematic and BoxCollider normal
        rb.isKinematic = false; 
        coll.isTrigger = false;
        
        //Disable script
        meleeScript.enabled = false;
    }

}
