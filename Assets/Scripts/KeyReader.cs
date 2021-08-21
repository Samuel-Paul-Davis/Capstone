using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyReader : SlotPuzzle
{
    public bool unlocked = false;

    private void Update()
    {
        if (slot_parts[0] && slot_parts[1] && slot_parts[0].GetComponent<KeyCoreObject>() && slot_parts[1].GetComponent<KeyCoreObject>())
            unlocked = true;
    }

    /*private void Start()
    {
        //if DRY could cry, oh my, why?
        if (slot1_key)
        {
            slot1_key.GetComponent<KeyCoreObject>().isActive = false;
            slot1_key.GetComponent<KeyCoreObject>().isMoving = false;
            slot1_key.GetComponent<Rigidbody>().isKinematic = true;

            slot1_key.transform.position = slot1.transform.position;
            slot1.GetComponent<Collider>().enabled = false;

            slot1_key.GetComponent<KeyCoreObject>().enabled = false;
            slot1_key.tag = "Untagged";
        }

        if (slot2_key)
        {
            slot2_key.GetComponent<KeyCoreObject>().isActive = false;
            slot2_key.GetComponent<KeyCoreObject>().isMoving = false;
            slot2_key.GetComponent<Rigidbody>().isKinematic = true;

            slot2_key.transform.position = slot2.transform.position;
            slot2.GetComponent<Collider>().enabled = false;

            slot2_key.GetComponent<KeyCoreObject>().enabled = false;
            slot2_key.tag = "Untagged";
        }
    }*/
}
