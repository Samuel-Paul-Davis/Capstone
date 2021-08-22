using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleEvents : MonoBehaviour
{
    public static PuzzleEvents current;

    private void Awake()
    {
        current = this;
    }

    public event Action<int> OnWeightTrigger;

    public void WeightTrigger(int id)
    {
        OnWeightTrigger?.Invoke(id);
    }
}
