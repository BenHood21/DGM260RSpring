using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : WeaponBase
{
    private Animator anim;
    
    public override void Attack()
    {
       anim.SetBool("Attacking", true);
      
    }

    public override void Sheath()
    {
        anim.SetBool("Attacking", false);
    }
    
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        // animation help from FPS Builders on Youtube
        if (Input.GetKeyDown(KeyCode.C)) anim.SetBool("Attacking", true);
        else if (Input.GetKeyUp(KeyCode.C)) anim.SetBool("Attacking", false);
    }
   
}
