using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerRouter : SlotPuzzle
{
    public Vector2Int gridSize;

    public GameObject inputSlot;
    public GameObject outputSlot;

    private GameObject[,] grid;

    private new void Start()
    {
        base.Start();

        grid = new GameObject[gridSize.x,gridSize.y];
    }

    private void Update()
    {
        for (int i = 0; i < gridSize.x; i++)
        {
            for (int j=0;j<gridSize.y;j++)
            {
                grid[i, j] = slot_parts[i + j];
            }
        }
    }
}
