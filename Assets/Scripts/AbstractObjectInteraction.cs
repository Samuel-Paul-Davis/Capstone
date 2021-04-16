using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractObjectInteraction : MonoBehaviour
{
    public abstract void ObjectInteraction(); // The function that is called when the object is selected
    public abstract void ObjectDeselectInteraction(); // The function that is called when the object is deselected, this can be left blank if no additional interaction is required
}