using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Missing Feature: Should accept slots being prefilled in the Unity Inspector
/// </summary>
public class KeyReader : SlotPuzzle
{
    //public bool unlocked = false;

    private void Update()
    {
        for (int i=0; i<slots.Count;i++)
        {
            if (slot_parts[i] && slot_parts[i].GetComponent<KeyCoreObject>())
                unlocked = true;
            else
            {
                unlocked = false;
                break;
            }
        }
    }
}
