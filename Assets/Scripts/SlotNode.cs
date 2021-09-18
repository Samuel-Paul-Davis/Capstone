using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotNode : MonoBehaviour
{
    [HideInInspector]
    public PowerBlockObject payload;
    public SlotNode next;

    public PowerBlockObject expectedPayload;
}
