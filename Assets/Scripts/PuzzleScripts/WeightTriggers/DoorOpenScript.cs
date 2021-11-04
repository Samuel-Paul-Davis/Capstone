using UnityEngine;

public class DoorOpenScript : BaseGatePuzzle
{

    [Header("Door Movement Variables")]
    public float timeToTarget = 1f;
    public bool closeOnTriggerRelease;

    [Tooltip("Amount of triggers required before the puzzle is activated")]
    public int maxTriggers = 1;

    private bool isDoorOpen;
    private Vector3 targetPosition;
    private Vector3 initialTransform;
    public int currentTriggers;

    private AudioSource audioSource;
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
        if (!TryGetComponent<AudioSource>(out audioSource))
        {
            Debug.LogWarning("No audio source found.");
        }
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
        if(id == triggerID)
        {
            currentTriggers += 1;
            if (!isDoorOpen)
            {
                if (TriggerCheck())
                {
                    LeanTween.moveLocal(gameObject, targetPosition, timeToTarget).setEaseOutQuad();
                    if(audioSource)
                        audioSource.Play();
                    isDoorOpen = true;
                }
            }
        }

    }

    private void CloseDoorway(int id)
    {
        if (id == triggerID)
        {
            currentTriggers -= 1;
            if (closeOnTriggerRelease && isDoorOpen)
            {
                LeanTween.moveLocal(gameObject, initialTransform, timeToTarget).setEaseOutQuad();
                isDoorOpen = false;
            }
        }
    }

    private bool TriggerCheck()
    {
        return currentTriggers >= maxTriggers;
    }
    private void OnDrawGizmos()
    {
        //DrawArrow.ForGizmo(transform.position, targetPosition, Color.red);
    }
}