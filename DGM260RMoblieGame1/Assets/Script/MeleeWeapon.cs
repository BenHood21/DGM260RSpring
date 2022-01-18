using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : WeaponBase
{
    private Animator anim;
    
    public override void Attack()
    {
        
    }
    
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        // animation help from FPS Builders on Youtube
        if (Input.GetButtonDown("Fire1")) anim.SetBool("Attacking", true);
        else if (Input.GetButtonUp("Fire1")) anim.SetBool("Attacking", false);
    }
   
}
