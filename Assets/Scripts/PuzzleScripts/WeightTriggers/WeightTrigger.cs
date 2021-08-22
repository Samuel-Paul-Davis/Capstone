using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightTrigger : MonoBehaviour
{
    [Header("Weight Options")]
    [Range(0f, 100f), Tooltip("Anthing >= WeightLimit will 'trigger' the weight")]
    public float weightLimit;


    [SerializeField]
    private bool isTriggered = false;
    private List<Rigidbody> currentRigidBodies = new List<Rigidbody>();
    private float currentTotalWeight;

    private void EventTriggerActive()
    {
        PuzzleEvents.current.WeightTrigger(GetInstanceID());
    }


    private void TriggerWeight()
    {
        currentTotalWeight = CalculateWeight();
        bool tempTrigger;
        tempTrigger = CheckWeight();
        if(isTriggered != tempTrigger)
        {
            if (isTriggered)
            {
                EventTrigger();
                transform.position = new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z);
            }
            else
            {
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
            print(other.name + " has rigidbody " + rb.mass + "kg");
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

    

}
