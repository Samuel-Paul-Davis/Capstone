using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheFirstPerson;

public class ClimbingController : TFPExtension
{
    public WallDetection wallDetection;
    public BoxCollider boxxy;

    private Animation animator;

    private bool _canBeginClimb;
    public bool _climbing;
    private bool _wallWithinRange;
    private Vector3 _climbingTarget;
    private Vector3 startingPosition;

    private void Start()
    {
        gameObject.GetComponent<WallDetection>();
    }

    private void Update()
    {
        if (_canBeginClimb)
        {
            //transform.position = Vector3.Lerp(transform.position, _climbingTarget, Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position, _climbingTarget, Time.deltaTime * 2f);
            if (transform.position == _climbingTarget)
            {
                print("Climbing has been completed");
                _canBeginClimb = false;
                _climbing = false;
            }
        }
    }

    public void ClimbUpLedge(Vector3 climbingPoint)
    {
        // Begin Animation
        print("Climbing up ledge has begun");
        startingPosition = transform.position;
        _climbingTarget = climbingPoint;
        _canBeginClimb = true;
        _climbing = true;
    }

    private void BeginClimb()
    {
        //Opposite normal to the wall
        //Play animation
        //If player is close enough to ledge grab
    }

    private void DropOffLedge()
    {
    }

    public override void ExPreUpdate(ref TFPData data, TFPInfo info)
    {
        data.movementEnabled = !_climbing;
    }
}