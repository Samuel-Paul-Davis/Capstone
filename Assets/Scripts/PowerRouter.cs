using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerRouter : SlotPuzzle
{
    public SlotNode inputSlot;
    public SlotNode outputSlot;

    public bool unlocked = false;

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
}

/*public class PowerRouter : SlotPuzzle
{
    public Vector2Int gridSize;
    public GameObject inputSlot;
    public GameObject outputSlot;

    private int[,] grid;

    private new void Start()
    {
        base.Start();

        grid = new int[gridSize.x,gridSize.y];
    }

    private void Update()
    {
        for (int i = 0; i < gridSize.x; i++)
        {
            for (int j=0;j<gridSize.y;j++)
            {
                if (slot_parts[i + j] && slot_parts[i + j].GetComponent<PowerBlockObject>())
                {
                    grid[i, j] = i + j;
                }
            }
        }
    }

    private void CheckConnection()
    {
        for (int i = 0; i < gridSize.x; i++)
        {
            for (int j = 0; j < gridSize.y; j++)
            {
                if (grid[i,j] == slots.IndexOf(inputSlot))
                {
                    //WIP
                }
            }
        }
    }

//    private bool IsAdjacent(Vector2Int a, Vector2Int b)
//    {
//        if ((a.x - b.x) <= 1 && (a.y - b.y) <= 1)
//            return true;

//        return false;
//    }
}*/