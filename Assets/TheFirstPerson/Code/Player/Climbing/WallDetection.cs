using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDetection : MonoBehaviour
{
    private bool wallDetected;
    private SphereCollider sphereCollider;

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
            LedgeDetection.DetectLedge(transform.position + (transform.forward * 2) + (transform.up * 2));
        }
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

    private void OnDrawGizmos()
    {
        Vector3 direction = new Vector3(0, -1, 0);
        Vector3 cent = transform.position + (transform.forward * 2) + (transform.up * 2);
        Gizmos.color = Color.red;
        //Draw a Ray forward from GameObject toward the maximum distance
        Gizmos.DrawRay(cent, direction * 1000f); ;
        //Draw a cube at the maximum distance
        Gizmos.DrawWireCube(cent + direction, transform.localScale);
    }
}