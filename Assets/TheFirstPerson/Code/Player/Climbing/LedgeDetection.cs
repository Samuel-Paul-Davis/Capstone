using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LedgeDetection : MonoBehaviour
{
    /// <summary>
    /// Casts a ray down to detect a ledge if a wall is hit
    /// </summary>
    /// <param name="center"></param>
    /// <param name="halfExtents"></param>
    /// <param name="direction"></param>
    /// <param name="orientation"></param>
    /// <param name="maxDistance"></param>
    /// <param name="drawCube"></param>
    /// <returns></returns>
    public static RaycastHit DetectLedge(Vector3 center, Vector3 halfExtents, Vector3 direction, Quaternion orientation, float maxDistance, bool drawCube)
    {
        //Layer
        LayerMask mask = 1 << 10;

        //Physics.BoxCast(center, halfExtents, direction, out RaycastHit raycastHit, orientation, maxDistance, mask);
        Physics.SphereCast(center, 1, direction, out RaycastHit raycastHit, maxDistance, mask);
        if (drawCube)
            DrawCubePoints(CubePoints(center, halfExtents, orientation, raycastHit.point));
        return raycastHit;
    }

    private static void DrawCubePoints(Vector3[] points)
    {
        Debug.DrawLine(points[0], points[1]);
        Debug.DrawLine(points[0], points[2]);
        Debug.DrawLine(points[0], points[4]);

        Debug.DrawLine(points[7], points[6]);
        Debug.DrawLine(points[7], points[5]);
        Debug.DrawLine(points[7], points[3]);

        Debug.DrawLine(points[1], points[3]);
        Debug.DrawLine(points[1], points[5]);

        Debug.DrawLine(points[2], points[3]);
        Debug.DrawLine(points[2], points[6]);

        Debug.DrawLine(points[4], points[5]);
        Debug.DrawLine(points[4], points[6]);
    }

    private static Vector3[] CubePoints(Vector3 center, Vector3 extents, Quaternion rotation, Vector3 hitPoint)
    {
        Vector3[] points = new Vector3[8];
        points[0] = rotation * Vector3.Scale(extents, new Vector3(1, 1, 1)) + center;
        points[1] = rotation * Vector3.Scale(extents, new Vector3(1, 1, -1)) + center;
        points[2] = rotation * Vector3.Scale(extents, new Vector3(1, -1, 1)) + hitPoint;
        points[3] = rotation * Vector3.Scale(extents, new Vector3(1, -1, -1)) + hitPoint;
        points[4] = rotation * Vector3.Scale(extents, new Vector3(-1, 1, 1)) + center;
        points[5] = rotation * Vector3.Scale(extents, new Vector3(-1, 1, -1)) + center;
        points[6] = rotation * Vector3.Scale(extents, new Vector3(-1, -1, 1)) + hitPoint;
        points[7] = rotation * Vector3.Scale(extents, new Vector3(-1, -1, -1)) + hitPoint;

        return points;
    }
}