using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheFirstPerson;
/// <summary>
/// Controls player hovering. Attaches to player controller. (Remember to add it to the PlayerController TFPExtensions.
/// </summary>
public class HoverController : TFPExtension
{
    public float length;
    public float strength;
    public float dampeningAmount;

    private float lastHitDist;

    public LayerMask layerMask;

    private void Start()
    {
        lastHitDist = 10;
    }


    public override void ExPostFixedUpdate(ref TFPData data, TFPInfo info)
    {
        base.ExPostFixedUpdate(ref data, info);
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.TransformDirection(-Vector3.up), Color.red);
        if (Physics.Raycast(transform.position, transform.TransformDirection(-Vector3.up), out hit, length, layerMask))
        {
            print(hit.collider.gameObject.name);
            float forceAmount = HooksLawDampen(hit.distance);

            //rb.AddForceAtPosition(transform.up * forceAmount, transform.position);

            data.yVel += forceAmount;
            print("Added " + forceAmount + " to yVel");
        }
        else
        {
            lastHitDist = length;
            print("Nothing hit");
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

    /// <summary>
    /// Dampens the up forces
    /// </summary>
    /// <param name="hitDistance">Distance from origin of cast to hit point</param>
    /// <returns></returns>
    private float DampenAmount(float hitDistance)
    {
        float dampen = dampeningAmount * (lastHitDist - hitDistance);
        return dampen;
    }
}
