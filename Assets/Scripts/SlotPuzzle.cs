using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotPuzzle : Puzzle
{
    public List<GameObject> slots;

    [SerializeField]
    protected GameObject[] slot_parts;

    protected void Start()
    {
        Transform[] children = transform.GetComponentsInChildren<Transform>();

        foreach (Transform child in children)
            if (child != transform)
                slots.Add(child.gameObject);

        slot_parts = new GameObject[slots.Count];
    }
}
