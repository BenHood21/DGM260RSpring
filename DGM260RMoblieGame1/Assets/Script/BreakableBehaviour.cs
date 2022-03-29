using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableBehaviour : MonoBehaviour
{
    public GameObject destroyedObj;

    private void OnTriggerEnter(Collider obj)
    {
        if (obj.tag == "Weapon")
        {
            Instantiate(destroyedObj, transform.position, transform.rotation);
            Destroy(gameObject);
            Debug.Log("Melee Hit");
        }
    }
    
}
