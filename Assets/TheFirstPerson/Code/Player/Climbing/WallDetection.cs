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

    private bool _grabLedge;

    public bool grabLedge
    {
        get { return _grabLedge; }
        set { _grabLedge = value; }
    }

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
            print("WallDetection: " + hit);
            CanBeClimbed(rayCastHit.point);
        }
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
        print("Wall detected");
    }

    private void OnTriggerExit(Collider other)
    {
        wallDetected = false;
        print("Wall de-detected");
    }
}