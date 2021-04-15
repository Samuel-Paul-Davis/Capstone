using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LedgeDetection : MonoBehaviour
{
    [Header("Box Cast Variables")]
    public Vector3 boxCastSize = new Vector3(1, 1, 1);

    public Vector3 detectionDirection = new Vector3(0, 0, -1);
    public Quaternion boxCastOrientation = new Quaternion(0, 0, 0, 0);
    public float maxDistance = 5f;

    private int layerMask = 1 << 10;

    private RaycastHit m_Hit;
    private bool m_HitDetect;

    //public static RaycastHit DetectLedge(Vector3 center)
    //{
    //    Physics.BoxCast(center, boxCastSize, detectionDirection, out m_Hit, boxCastOrientation, maxDistance, layerMask);
    //    return m_Hit;
    //}

    public static RaycastHit DetectLedge(Vector3 center)
    {
        RaycastHit raycastHit;
        if (Physics.BoxCast(center, new Vector3(2, 2, 2), new Vector3(0, -1, 0), out raycastHit, new Quaternion(0, 0, 0, 0), 10000f, 10))
            print("Hitted");

        return raycastHit;
    }
}