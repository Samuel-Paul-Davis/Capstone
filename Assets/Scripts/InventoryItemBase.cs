using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableItemBase : MonoBehaviour
{
    public string Name;
    public Sprite Image;
    public string InteractText = "E to interact";

    public virtual void OnInteract()
    {

    }
}

public class InventoryItemBase : InteractableItemBase
{

}