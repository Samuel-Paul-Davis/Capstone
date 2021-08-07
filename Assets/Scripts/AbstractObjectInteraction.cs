using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractObjectInteraction : MonoBehaviour
{
    protected bool isDiscovered = false; // Used for the scanning tool, call the function, "Discover" to make True
    public abstract void ObjectInteraction(); // The function that is called when the object is selected
    public abstract void ObjectDeselectInteraction(); // The function that is called when the object is deselected, this can be left blank if no additional interaction is required

    // This can be overridden by children so that they can do specific things when they are discovered, such as change materials or make things appear
    public virtual void Discover()
    {
        isDiscovered = true;
    }
}