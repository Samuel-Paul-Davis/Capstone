using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Missing Feature: Should accept slots being prefilled in the Unity Inspector
/// </summary>
public class KeyReader : SlotPuzzle
{
    //public bool unlocked = false;
    private AudioSource audioSource;

    //Triggers sound once. Is recent when door is locked.
    private bool soundTrigger = false;

    private void Awake()
    {
        if (!TryGetComponent<AudioSource>(out audioSource))
            Debug.LogWarning("No AudioSource Component on: " + name);
    }
    private void Update()
    {
        for (int i=0; i<slots.Count;i++)
        {
            if (slots[i].transform.childCount > 0 && slots[i].transform.GetChild(0).GetComponent<SlotPartObject>() != null)
            {
                unlocked = true;
                TriggerSound();
            }
            else
                unlocked = false;
        }

        /*for (int i=0; i<slots.Count;i++)
        {
            if (slot_parts[i] && slot_parts[i].GetComponent<KeyCoreObject>())
            {
                TriggerSound();
                unlocked = true;
            }
            else
            {
                unlocked = false;
                soundTrigger = false;
                break;
            }
        }*/
    }

    private void TriggerSound()
    {
        if (!soundTrigger)
        {
            audioSource.Play();
            soundTrigger = true;
        }
    }

}
