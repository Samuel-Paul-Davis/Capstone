using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheFirstPerson;

public class ClimbingController : TFPExtension
{
    public WallDetection wallDetection;
    public BoxCollider boxxy;

    private void Start()
    {
        gameObject.GetComponent<WallDetection>();
    }

    public override void ExPreUpdate(ref TFPData data, TFPInfo info)
    {
        try
        {
            print(wallDetection.hit);
            if (wallDetection.hit)
            {
                data.yVel = 5;
                data.gravMult = 0;
                if (boxxy.transform.position.y >= wallDetection.rayCastHit.point.y)
                {
                    data.yVel = 0;
                    data.currentMove = Vector3.zero;
                    data.movementEnabled = false;
                }
            }
        }
        catch (System.NullReferenceException)
        {
            print("NULL object");
        }
    }
}