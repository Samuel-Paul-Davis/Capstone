using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : AbstractObjectInteraction
{
    [SerializeField]
    private TempMovingObject moveObject;

    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void ObjectDeselectInteraction()
    {
        
    }

    public override void ObjectInteraction()
    {
        //Debug.Log(moveObject.returnHome);
        if (moveObject.returnHome)
            moveObject.returnHome = false;
        else
            moveObject.returnHome = true;
    }
}