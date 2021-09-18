using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverObject : AbstractObjectInteraction
{
    public bool isOn = false;

    private void Update()
    {
        if (GetComponent<HingeJoint>().angle > 0)
            isOn = true;
        else
            isOn = false;
    }

    public override void ObjectInteraction()
    {
        JointSpring js = GetComponent<HingeJoint>().spring;

        js.targetPosition *= -1;

        GetComponent<HingeJoint>().spring = js;
    }

    public override void ObjectDeselectInteraction() {}

    public void TurnOn()
    {
        isOn = true;
    }

    public void TurnOff()
    {
        isOn = false;
    }
}
