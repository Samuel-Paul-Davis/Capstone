using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    public Material[] materials;

    private Dictionary<Renderer, Material[]> oldMats = new Dictionary<Renderer, Material[]>();

    private void OnTriggerEnter(Collider other)
    {
        oldMats.Add(other.gameObject.GetComponent<Renderer>(), other.gameObject.GetComponent<Renderer>().materials);

        other.gameObject.GetComponent<Renderer>().materials = materials;
    }

    private void OnTriggerExit(Collider other)
    {
        Renderer otherRenderer = other.gameObject.GetComponent<Renderer>();

        otherRenderer.materials = oldMats[otherRenderer];

        oldMats.Remove(otherRenderer);
    }
}
