using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverObject : AbstractObjectInteraction
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void ObjectInteraction()
    {
        JointSpring js = GetComponent<HingeJoint>().spring;

        js.targetPosition *= -1;

        GetComponent<HingeJoint>().spring = js;
    }

    public override void ObjectDeselectInteraction()
    {
        throw new System.NotImplementedException();
    }
}
