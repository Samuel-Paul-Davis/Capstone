using System.Collections.Generic;
using UnityEngine;

public class WeightTrigger : MonoBehaviour
{
    [Header("Weight Options")]
    [Range(0f, 10f), Tooltip("Anthing >= WeightLimit will 'trigger' the weight")]
    public float weightLimit;

    [Tooltip("Puzzle Objects with this ID will be activated")]
    public int triggerID;

    [SerializeField]
    private bool isTriggered = false;

    [SerializeField]
    private AudioSource triggerActiveSound;
    [SerializeField]
    private AudioSource triggerReleaseSound;

    public PuzzleState State {
        get
        {
            if (isTriggered)
                return PuzzleState.On;
            else
                return PuzzleState.Off;
        }
    }

    private List<Rigidbody> currentRigidBodies = new List<Rigidbody>();
    private float currentTotalWeight;

    private void Start()
    {
        ShowDoorLocations();    
    }


    private void TriggerWeight()
    {
        currentTotalWeight = CalculateWeight();
        bool tempTrigger;
        tempTrigger = CheckWeight();
        if (isTriggered != tempTrigger)
        {
            if (isTriggered)
            {
                EventTriggerDeactive();
                triggerActiveSound.Play();
                transform.position = new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z);
            }
            else
            {
                EventTriggerActive();
                triggerReleaseSound.Play();
                transform.position = new Vector3(transform.position.x, transform.position.y - 0.1f, transform.position.z);
            }
            isTriggered = tempTrigger;
        }
    }

    /// <summary>
    /// Calculates the combined weight of the rigidbodies within the trigger
    /// </summary>
    /// <returns></returns>
    private float CalculateWeight()
    {
        print("=====Rigidbodies currently in List=====");
        float totalWeight = 0;
        foreach (Rigidbody rigidbody in currentRigidBodies)
        {
            print(rigidbody.name);
            totalWeight += rigidbody.mass;
        }
        print("===================================");
        return totalWeight;
    }

    /// <summary>
    /// Checks if the weight is >= WeightLimit and triggers if it is
    /// </summary>
    private bool CheckWeight()
    {
        if (currentTotalWeight >= weightLimit)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb;
        if (other.TryGetComponent<Rigidbody>(out rb))
        {
            currentRigidBodies.Add(rb);
            TriggerWeight();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Rigidbody rb;
        if (other.TryGetComponent<Rigidbody>(out rb))
        {
            currentRigidBodies.Remove(rb);
        }
        TriggerWeight();
    }


    private void EventTriggerActive()
    {
        PuzzleEvents.current.WeightTriggered(triggerID);
    }

    private void EventTriggerDeactive()
    {
        PuzzleEvents.current.WeightDeTriggered(triggerID);
    }


    /// <summary>
    /// Calls ShowDoorLocations, which draws a line to all puzzle elements that are effected by this trigger
    /// </summary>
    private void ShowDoorLocations()
    {
        PuzzleEvents.current.ShowDoorLocations(triggerID, transform.position);
    }
}