using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBlockObject : SlotPartObject
{
    public Connections connections;
}

[System.Serializable]
public struct Connections
{
    public bool left;
    public bool right;
    public bool top;
    public bool bottom;
}