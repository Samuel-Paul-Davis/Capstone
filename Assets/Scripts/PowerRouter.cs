using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerRouter : SlotPuzzle
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

    /*private bool IsAdjacent(Vector2Int a, Vector2Int b)
    {
        if ((a.x - b.x) <= 1 && (a.y - b.y) <= 1)
            return true;

        return false;
    }*/
}
