using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheFirstPerson;
using UnityEngine.Animations.Rigging;

internal enum ClimbingState
{
    ClimbFalse,
    ClimbStart,
    ClimbStartEnd,
    ClimbHangStart,
    ClimbPointHangIdle,
    ClimbNextPointStart,
    ClimbNextPointEnd,
    ClimbLedgeHangStart,
    ClimbLedgeHangIdle,
    ClimbLedgeHangEnd,
    ClimbUpLedgeStart,
    ClimbUpLedgeCurrent,
    ClimbUpLedgeEnd,
    ClimbDrop,
    ClimbEnd
}

public class ClimbingController : TFPExtension
{
    public WallDetection wallDetection;
    public BoxCollider boxxy;

    private Animator animator;
    private RigBuilder rigBuilder;

    private bool _canBeginClimb;
    public bool _climbing;
    public GameObject handPosition;
    public GameObject HangingDistance;
    private bool _wallWithinRange;
    private Vector3 _climbingTarget;
    private Vector3 startingPosition;

    private ClimbingState currentState;

    private float vertDistance;

    private void Start()
    {
        try
        {
            animator = GetComponentInChildren<Animator>();
            rigBuilder = GetComponentInChildren<RigBuilder>();
            wallDetection = GetComponent<WallDetection>();
            vertDistance = HangingDistance.transform.position.y - transform.position.y;
            print("VertDistance = " + vertDistance);
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
            StartIK();
            Vector3 lerpTarget = new Vector3(transform.position.x, _climbingTarget.y - vertDistance, transform.position.z);

            if (currentState == ClimbingState.ClimbStart)
            {
                if (transform.position != lerpTarget)
                {
                    transform.position = Vector3.MoveTowards(transform.position, lerpTarget, Time.deltaTime * 2f);
                }
                else if (transform.position == lerpTarget)
                {
                    currentState = ClimbingState.ClimbLedgeHangIdle;
                }
            }

            if (currentState == ClimbingState.ClimbLedgeHangIdle)
            {
                if (Input.GetKeyDown("w"))
                {
                    currentState = ClimbingState.ClimbUpLedgeStart;
                }
                if (Input.GetKeyDown("s"))
                {
                    currentState = ClimbingState.ClimbDrop;
                }
            }

            if (currentState == ClimbingState.ClimbUpLedgeStart)
            {
                EndIK();
                animator.SetTrigger("climbingUpLedge");
                currentState = ClimbingState.ClimbUpLedgeCurrent;
            }

            if (currentState == ClimbingState.ClimbUpLedgeCurrent)
            {
                transform.position = Vector3.MoveTowards(transform.position, _climbingTarget, Time.deltaTime * 2f);
                if (transform.position == _climbingTarget)
                {
                    currentState = ClimbingState.ClimbUpLedgeEnd;
                }
            }

            if (currentState == ClimbingState.ClimbUpLedgeEnd)
            {
                print("Climbing has been completed");
                _canBeginClimb = false;
                _climbing = false;
                animator.SetBool("isHanging", false);
            }
            if (currentState == ClimbingState.ClimbDrop)
            {
                _canBeginClimb = false;
                _climbing = false;
                animator.SetBool("isHanging", false);
                currentState = ClimbingState.ClimbEnd;
                EndIK();
            }
        }
        print(currentState);
    }

    private void EndIK()
    {
        rigBuilder.enabled = false;
    }

    private void StartIK()
    {
        if (_climbingTarget != null)
            handPosition.transform.position = _climbingTarget;
        rigBuilder.enabled = true;
    }

    public void ClimbUpLedge(Vector3 climbingPoint)
    {
        if (!_climbing)
        {
            // Begin Animation
            print("Climbing up ledge has begun");
            startingPosition = transform.position;
            _climbingTarget = climbingPoint;
            _canBeginClimb = true;
            _climbing = true;
            rigBuilder.enabled = true;
            animator.SetBool("isHanging", true);
            currentState = ClimbingState.ClimbStart;
        }
    }

    public void HangOnLedge()
    {
        StartIK();
    }

    public void ClimbUpLedge()
    {
        EndIK();
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

    //TODO: Use ClimbingState in functions
    /// <summary>
    /// Sets the relevant variables for climbing state
    /// </summary>
    private void setStateVariables()
    {
        switch (currentState)
        {
            case ClimbingState.ClimbStart:

                break;

            case ClimbingState.ClimbStartEnd:
                break;

            case ClimbingState.ClimbHangStart:
                break;

            case ClimbingState.ClimbPointHangIdle:
                break;

            case ClimbingState.ClimbNextPointStart:
                break;

            case ClimbingState.ClimbNextPointEnd:
                break;

            case ClimbingState.ClimbLedgeHangStart:
                break;

            case ClimbingState.ClimbLedgeHangIdle:
                break;

            case ClimbingState.ClimbLedgeHangEnd:
                break;

            case ClimbingState.ClimbUpLedgeStart:
                break;

            case ClimbingState.ClimbUpLedgeEnd:
                break;

            case ClimbingState.ClimbDrop:
                break;

            case ClimbingState.ClimbEnd:
                break;

            default:
                break;
        }
    }

    public override void ExPreUpdate(ref TFPData data, TFPInfo info)
    {
        data.movementEnabled = !_climbing;
    }
}