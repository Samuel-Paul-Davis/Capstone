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

        if (node.payload != node.expectedPayload)
            return false;

        if (node == inputSlot)
            node.payload.isPowered = true;
        else
            node.payload.isPowered = node.prev.payload.isPowered;

        bool retVal = node.payload.isPowered;

        if (retVal && node != outputSlot)
            retVal = ConnectNodes(node.next);

        return retVal;
    }
}