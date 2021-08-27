using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseGatePuzzle : MonoBehaviour
{
    [Tooltip("Puzzle will only be triggered if ids match")]
    public int triggerID;

    [Tooltip("Enable to show line to trigger")]
    public bool debugLine;

    private void Awake()
    {
        if(debugLine)
            PuzzleEvents.current.OnShowLocation += DrawLocationToTrigger;
    }

    /// <summary>
    /// Draws a line to from current location to new location
    /// </summary>
    /// <param name="id">Only draws line if id and triggerID match</param>
    /// <param name="location">Location of second point</param>
    protected void DrawLocationToTrigger(int id, Vector3 location)
    {
        if(id == triggerID)
        {
            
            LineRenderer lineRenderer = new GameObject("Line-" + GetInstanceID()).AddComponent<LineRenderer>();
            lineRenderer.transform.parent = transform;
            lineRenderer.startColor = Color.green;
            lineRenderer.endColor = Color.green;
            lineRenderer.startWidth = 0.25f;
            lineRenderer.endWidth = 0.25f;
            lineRenderer.positionCount = 2;
            lineRenderer.useWorldSpace = true;

            lineRenderer.SetPosition(0, transform.position); //x,y and z position of the starting point of the line
            lineRenderer.SetPosition(1, location); //x,y and z position of the end point of the line
        }
    }
}
