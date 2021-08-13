using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverObject : AbstractObjectInteraction
{
    public bool isOn = false;


    private float targetPos;

    private void Update()
    {
        Debug.Log(GetComponent<HingeJoint>().angle + ", " + targetPos);
        Debug.Log(GetComponent<HingeJoint>().angle == targetPos);

        if (Mathf.Approximately(GetComponent<HingeJoint>().angle,targetPos))
        {
            if (isOn)
                isOn = false;
            else
                isOn = true;
        }
    }

    public override void ObjectInteraction()
    {
        JointSpring js = GetComponent<HingeJoint>().spring;

        js.targetPosition *= -1;

        GetComponent<HingeJoint>().spring = js;

        targetPos = js.targetPosition;
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
