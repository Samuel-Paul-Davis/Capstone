using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float length;
    public float strength;

    private void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(-Vector3.up), out hit, length))
        {
             
        }
    }

    private float HooksLaw()
    {
        float forceAmount = 0;

        forceAmount = strength 
    }

    private float DampenAmount()
    {

    }
}
