using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDetection : MonoBehaviour
{
    public Vector3 ledgeDetectionBoxScale = new Vector3(1, 1, 1);
    public Vector3 ledgeDetectionBoxCenter = new Vector3(2, 5, 1);
    public float LedgeDetectionDistance = 1000f;
    private bool wallDetected;
    private SphereCollider sphereCollider;
    public RaycastHit rayCastHit;

    public ClimbingController climbingController;
    public bool hit;

    // Start is called before the first frame update
    private void Start()
    {
        sphereCollider = GetComponent<SphereCollider>();

        if (sphereCollider)
        {
            Debug.LogWarning("Sphere Collider is null");
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (wallDetected)
        {
            rayCastHit = LedgeDetection.DetectLedge((transform.position * ledgeDetectionBoxCenter.x) + (transform.up * ledgeDetectionBoxCenter.y) + (transform.forward * ledgeDetectionBoxCenter.z), ledgeDetectionBoxScale, new Vector3(0, -1, 0), new Quaternion(0, 0, 0, 0), LedgeDetectionDistance, true);
            if (rayCastHit.point == Vector3.zero)
            {
                hit = false;
            }
            else
            {
                hit = true;
            }
            CanBeClimbed(rayCastHit.point);

            if (hit && Input.GetKeyDown("w"))
            {
                print("Climbing inputs gotten");
                StartClimbing(rayCastHit);
            }
        }
    }

    private void StartClimbing(RaycastHit rayhit)
    {
        climbingController.ClimbUpLedge(rayhit.point);
    }

    private bool CanBeClimbed(Vector3 point)
    {
        float distBA = Vector3.Distance(transform.position, point);
        if (distBA < 2.45)
        {
            Debug.DrawLine(transform.position, point, Color.green);
            return true;
        }
        Debug.DrawLine(transform.position, point, Color.red);
        return false; ;
    }

    private void OnTriggerEnter(Collider other)
    {
        wallDetected = true;
    }

    private void OnTriggerExit(Collider other)
    {
        wallDetected = false;
    }
}