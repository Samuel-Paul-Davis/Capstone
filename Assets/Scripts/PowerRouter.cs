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

        if (node.next == null && node != outputSlot)
            return false;

        if (node.payload != node.expectedPayload)
            return false;

        bool retVal = true;

        node.payload.isPowered = true;

        if (node != outputSlot)
            retVal = ConnectNodes(node.next);

        return retVal;
    }

    private new void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);

        collision.GetContact(0).thisCollider.gameObject.GetComponent<SlotNode>().payload = collision.GetContact(0).otherCollider.gameObject.GetComponent<PowerBlockObject>();
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.gameObject.TryGetComponent<PowerBlockObject>(out PowerBlockObject block))
        {
            block.isPowered = false;
        }
    }
}