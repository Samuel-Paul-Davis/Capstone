using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheFirstPerson;
using UnityEngine.Animations.Rigging;

public class ClimbingController : TFPExtension
{
    public WallDetection wallDetection;
    public BoxCollider boxxy;

    private Animator animator;
    private RigBuilder rigBuilder;

    private bool _canBeginClimb;
    public bool _climbing;
    private bool _wallWithinRange;
    private Vector3 _climbingTarget;
    private Vector3 startingPosition;

    private void Start()
    {
        try
        {
            rigBuilder = GetComponentInChildren<RigBuilder>();
            wallDetection = GetComponent<WallDetection>();
        }
        catch (System.NullReferenceException e)
        {
            Debug.LogError("NullReferenceException: " + e.Message);
            throw;
        }
    }

    private void Update()
    {
        if (_canBeginClimb)
        {
            //transform.position = Vector3.Lerp(transform.position, _climbingTarget, Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position, _climbingTarget, Time.deltaTime * 2f);
            if (transform.position == _climbingTarget)
            {
                animator.ResetTrigger("climbingUpLedge");
                print("Climbing has been completed");
                _canBeginClimb = false;
                _climbing = false;
                animator.SetBool("isHanging", false);
                animator.SetTrigger("climbingUpLedge");
                EndIK();
            }
        }
    }

    private void EndIK()
    {
        rigBuilder.enabled = false;
    }

    private void StartIK()
    {
        rigBuilder.enabled = true;
    }

    public void ClimbUpLedge(Vector3 climbingPoint)
    {
        // Begin Animation
        print("Climbing up ledge has begun");
        startingPosition = transform.position;
        _climbingTarget = climbingPoint;
        _canBeginClimb = true;
        _climbing = true;
        rigBuilder.enabled = true;
        animator.SetBool("isHanging", true);
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