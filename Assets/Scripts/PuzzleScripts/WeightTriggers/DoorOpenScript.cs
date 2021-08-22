using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenScript : MonoBehaviour
{
    public GameObject triggerObject;
    public int triggerID;
    private void Start()
    {
        PuzzleEvents.current.OnWeightTrigger += OpenDoorway;
        PuzzleEvents.current.OffWeightTrigger += CloseDoorway;
    }

    private void OpenDoorway(int id)
    {
        if(id == triggerID)
        {
            LeanTween.moveLocalY(gameObject, gameObject.transform.position.y + 6f, 1f).setEaseOutQuad();
        }
    }

    private void CloseDoorway(int id)
    {
        if (id == triggerID)
        {
            LeanTween.moveLocalY(gameObject, gameObject.transform.position.y - 6f, 1f).setEaseOutQuad();
        }
    }
}
