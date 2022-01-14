using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableBehaviour : MonoBehaviour
{
    public GameObject destroyedObj;
    private void OnMouseDown()
    {
        Instantiate(destroyedObj, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
