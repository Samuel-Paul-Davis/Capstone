using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleEvents : MonoBehaviour
{
    public static PuzzleEvents current;

    PuzzleEvents()
    {
        current = this;
    }

    public event Action<int> OnWeightTrigger;
    public event Action<int> OffWeightTrigger;
    public event Action<int,Vector3> OnShowLocation;

    public void WeightTriggered(int id)
    {
        OnWeightTrigger?.Invoke(id);
    }
    public void WeightDeTriggered(int id)
    {
        OffWeightTrigger?.Invoke(id);
    }

    public void ShowDoorLocations(int id, Vector3 currentLocation)
    {
        OnShowLocation?.Invoke(id, currentLocation);
    }

}
