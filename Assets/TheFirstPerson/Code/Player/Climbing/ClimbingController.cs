using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheFirstPerson;

public class ClimbingController : TFPExtension
{
    public WallDetection wallDetection;
    public BoxCollider boxxy;

    private bool _canBeginClimb;
    private bool _climbing;
    private bool _wallWithinRange;

    public bool CanBeginClimb
    {
        get { return _canBeginClimb; }
        set { _canBeginClimb = value; }
    }


    private void Start()
    {
        gameObject.GetComponent<WallDetection>();
    }
    private void Update()
    {
        //TODO: Move to seperate function and use callback when you press forward against a wall.
        if(_canBeginClimb && _wallWithinRange && Input.GetKey("W"))
        {

        }
    }

    private void MovePlayer()
    {
        
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