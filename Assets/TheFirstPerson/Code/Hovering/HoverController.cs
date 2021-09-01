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

    private const float MaxYVel = 0.5f;
    private const float MinYVel = -1;

    public LayerMask layerMask;

    private void Start()
    {
        lastHitDist = 1;
    }


    public override void ExPostFixedUpdate(ref TFPData data, TFPInfo info)
    {

        base.ExPostFixedUpdate(ref data, info);
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.TransformDirection(-Vector3.up), Color.red);
        bool hasHit = Physics.Raycast(transform.position, transform.TransformDirection(-Vector3.up), out hit, length, layerMask, QueryTriggerInteraction.Ignore);
        if (hasHit)
        {
            float forceAmount;
            if (NormalCheck(hit.normal, info.controller))
            {
                print("Slide = true");
            }
            else
            {
                print("Slide = false");
            }
            forceAmount = HooksLawDampen(hit.distance);

            if (data.grounded)
            {
                Mathf.Clamp(data.yVel, MinYVel, MaxYVel);
            }
            data.yVel += forceAmount;
            data.grounded = true;
            print($"Current yVel: {data.yVel}");
        }
        else
        {
            data.grounded = false;
            lastHitDist = length;
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

    private bool NormalCheck(Vector3 normal, CharacterController controller)
    {
        if (Vector3.Angle(normal, Vector3.up) >= controller.slopeLimit)
        {
            return true;
        }
        return false;
    }
}
