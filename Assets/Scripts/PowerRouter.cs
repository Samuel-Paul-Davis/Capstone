using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerRouter : SlotPuzzle
{
    public SlotNode inputSlot;
    public SlotNode outputSlot;

    //public bool unlocked = false;

    private void Update()
    {
        unlocked = ConnectNodes(inputSlot);
    }

    private bool ConnectNodes(SlotNode node)
    {
        if (node == null || node.payload == null)
            return false;

        /*if (node.next == null && node != outputSlot)
            return false;*/

        if (node.payload != node.expectedPayload)
            return false;

        //bool retVal = true;

        if (node == inputSlot)
            node.payload.isPowered = true;
        else
            node.payload.isPowered = node.prev.payload.isPowered;

        bool retVal = node.payload.isPowered;

        if (retVal && node != outputSlot)
            retVal = ConnectNodes(node.next);

        return retVal;
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(name + " OnTriggerEnter(" + other.name + ")");
    }

    /*private new void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);

        collision.GetContact(0).thisCollider.gameObject.GetComponent<SlotNode>().payload = collision.GetContact(0).otherCollider.gameObject.GetComponent<PowerBlockObject>();
    }

    private void OnCollisionExit(Collision collision)
    {
        collision.collider.GetComponent<PowerBlockObject>().isPowered = false;
        collision.collider.transform.parent.GetComponent<SlotNode>().payload = null;
        //collision.collider.transform.parent.DetachChildren(); // causes an "object not found" error
    }*/


}