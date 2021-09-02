using UnityEngine;

public class DoorOpenScript : BaseGatePuzzle
{

    [Header("Door Movement Variables")]
    public float timeToTarget = 1f;
    public bool closeOnTriggerRelease;

    private bool isDoorOpen;
    private Vector3 targetPosition;
    private Vector3 initialTransform;

    public bool DoorOpen
    {
        get { return isDoorOpen; }
        set { isDoorOpen = value; }
    }

    private void Start()
    {
        initialTransform = transform.position;
        targetPosition = GetTargetPosition();
        PuzzleEvents.current.OnWeightTrigger += OpenDoorway;
        PuzzleEvents.current.OffWeightTrigger += CloseDoorway;
    }

    private Vector3 GetTargetPosition()
    {
        try
        {
            Transform tr = GetComponentInChildren<Transform>().Find("TargetPosition");
            GameObject go = tr.gameObject;
            return go.transform.position;
        }
        catch (System.NullReferenceException)
        {
            Debug.LogError("NullReferenceException: No TargetPosition GameObject");
            throw;
        }
    }

    /// <summary>
    /// Opens doorway to target position
    /// </summary>
    /// <param name="id"></param>
    private void OpenDoorway(int id)
    {
        if (id == triggerID && !isDoorOpen)
        {
            LeanTween.moveLocal(gameObject, targetPosition, timeToTarget).setEaseOutQuad();
            isDoorOpen = true;
        }
    }

    private void CloseDoorway(int id)
    {
        if (id == triggerID && closeOnTriggerRelease && isDoorOpen)
        {
            LeanTween.moveLocal(gameObject, initialTransform, timeToTarget).setEaseOutQuad();
            isDoorOpen = false;
        }
    }

    private void OnDrawGizmos()
    {
        //DrawArrow.ForGizmo(transform.position, targetPosition, Color.red);
    }
}