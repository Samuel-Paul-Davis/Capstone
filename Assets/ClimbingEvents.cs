using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbingEvents : MonoBehaviour
{
    public void ClimbEnd()
    {
        ClimbingController cc = GetComponentInParent<ClimbingController>();
        cc.ClimbUpLedgeEndEvent();
    }
}