using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotNode : MonoBehaviour
{
    [HideInInspector]
    public PowerBlockObject payload;
    public SlotNode prev;
    public SlotNode next;

    public PowerBlockObject expectedPayload;

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(name + " OnTriggerEnter(" + other.name + ")");

        if (other.GetComponent<SlotPartObject>() != null && transform.childCount == 0)
        {
            other.transform.SetParent(transform, false);
            other.transform.localPosition = Vector3.zero;
            other.transform.localRotation = Quaternion.identity;

            payload = other.GetComponent<PowerBlockObject>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (transform.childCount > 0)
        {
            payload.isPowered = false;

            transform.DetachChildren();
            payload = null;
        }
    }
}