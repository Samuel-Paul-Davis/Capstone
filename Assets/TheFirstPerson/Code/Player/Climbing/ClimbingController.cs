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
    private Vector3 lerpTarget;

    [Header("Climbing")]
    [SerializeField] private Vector3 playerHangingPosition;

    [SerializeField] private Vector3 playerHandsPosition;

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
            setStateVariables();
        }
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

    /// <summary>
    /// Begins character climbing
    /// </summary>
    /// <param name="climbingPoint"></param>
    public void ClimbUpLedge(Vector3 climbingPoint)
    {
        if (!_climbing)
        {
            // Begin Animation
            print("Climbing up ledge has begun");
            startingPosition = transform.position;
            _canBeginClimb = true;
            _climbingTarget = climbingPoint;
            _climbing = true;
            rigBuilder.enabled = true;
            lerpTarget = new Vector3(transform.position.x, _climbingTarget.y - vertDistance, transform.position.z);

            animator.SetBool("isHanging", true);
            currentState = ClimbingState.ClimbStart;
        }
    }

    public void ClimbEnd()
    {
        print("Ending Climb");
        currentState = ClimbingState.ClimbEnd;
    }

    private void ClimbStart()
    {
        StartIK();
        handPosition.transform.position = _climbingTarget + playerHandsPosition;

        print(lerpTarget);
        if (transform.position != lerpTarget)
        {
            transform.position = Vector3.MoveTowards(transform.position, lerpTarget, Time.deltaTime * 2f);
        }
        else if (transform.position == lerpTarget)
        {
            startingPosition = transform.position;
            currentState = ClimbingState.ClimbPointHangIdle;
        }
    }

    private void ClimbPointHangIdle()
    {
        if (transform.position != lerpTarget)
        {
            transform.position = Vector3.MoveTowards(transform.position, lerpTarget, Time.deltaTime * 2f);
        }
        else if (transform.position == lerpTarget)
        {
            lerpTarget = playerHangingPosition + startingPosition;
        }
        handPosition.transform.position = _climbingTarget + playerHandsPosition;

        print(lerpTarget);
    }

    private void ClimbLedgeHangIdle()
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

    private void ClimbUpLedgeStart()
    {
        //EndIK();
        animator.SetTrigger("climbingUpLedge");
        currentState = ClimbingState.ClimbUpLedgeCurrent;
    }

    private void ClimbUpLedgeCurrent()
    {
    }

    private void ClimbDrop()
    {
        _canBeginClimb = false;
        _climbing = false;
        animator.SetBool("isHanging", false);
        currentState = ClimbingState.ClimbEnd;
        EndIK();
    }

    private void ClimbUpLedgeEnd()
    {
        print("Climbing has been completed");
        _canBeginClimb = false;
        _climbing = false;
        animator.SetBool("isHanging", false);
    }

    public void ClimbUpLedgeEndEvent()
    {
        currentState = ClimbingState.ClimbUpLedgeEnd;
    }

    /// <summary>
    /// Sets the relevant variables for climbing state
    /// </summary>
    private void setStateVariables()
    {
        switch (currentState)
        {
            case ClimbingState.ClimbFalse:
                break;

            case ClimbingState.ClimbStart:
                ClimbStart();
                break;

            case ClimbingState.ClimbStartEnd:
                break;

            case ClimbingState.ClimbHangStart:
                break;

            case ClimbingState.ClimbPointHangIdle:
                ClimbPointHangIdle();
                break;

            case ClimbingState.ClimbNextPointStart:
                break;

            case ClimbingState.ClimbNextPointEnd:
                break;

            case ClimbingState.ClimbLedgeHangStart:
                break;

            case ClimbingState.ClimbLedgeHangIdle:
                ClimbLedgeHangIdle();

                break;

            case ClimbingState.ClimbLedgeHangEnd:
                break;

            case ClimbingState.ClimbUpLedgeStart:
                ClimbUpLedgeStart();

                break;

            case ClimbingState.ClimbUpLedgeCurrent:
                ClimbUpLedgeCurrent();
                break;

            case ClimbingState.ClimbUpLedgeEnd:
                ClimbUpLedgeEnd();

                break;

            case ClimbingState.ClimbDrop:
                ClimbDrop();

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