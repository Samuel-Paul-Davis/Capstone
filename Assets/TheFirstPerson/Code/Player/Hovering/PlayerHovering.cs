using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHovering : MonoBehaviour
{
    public float length;
    public float strength;
    public float dapeningAmount;

    private float lastHitDist;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        lastHitDist = 10;
    }

    private void FixedUpdate()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.TransformDirection(-Vector3.up), Color.red);
        if (Physics.Raycast(transform.position, transform.TransformDirection(-Vector3.up), out hit, length))
        {
            print(hit.collider.gameObject.name);
            float forceAmount = HooksLawDampen(hit.distance);

            rb.AddForceAtPosition(transform.up * forceAmount, transform.position);
        }
        else
        {
            lastHitDist = length;
            Debug.Log(hit.collider.gameObject.name);
        }

    }

    /// <summary>
    /// Applies hooks law and dampens the forces to make the object 'springy'
    /// </summary>
    /// <param name="hitDistance">Distance from origin of cast to hit point</param>
    /// <returns></returns>
    private float HooksLawDampen(float hitDistance)
    {
        float forceAmount = strength * (length - hitDistance) / length + DampenAmount(hitDistance);

        //Stops from pulling down
        forceAmount = Mathf.Max(0f, forceAmount);

        //Last hit dist is used for dampening
        lastHitDist = hitDistance;

        return forceAmount;

    }

    private float DampenAmount(float hitDistance)
    {
        float dampen = dapeningAmount * (lastHitDist - hitDistance);
        return dampen;
    }
}
