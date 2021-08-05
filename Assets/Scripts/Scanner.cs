using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    public Material[] materials;

    private Dictionary<Renderer, Material[]> oldMats = new Dictionary<Renderer, Material[]>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Interactive"))
        {
            oldMats.Add(other.gameObject.GetComponent<Renderer>(), other.gameObject.GetComponent<Renderer>().materials);

            other.gameObject.GetComponent<Renderer>().materials = materials;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Interactive"))
        {
            Renderer otherRenderer = other.gameObject.GetComponent<Renderer>();

            otherRenderer.materials = oldMats[otherRenderer];

            oldMats.Remove(otherRenderer);
        }
    }
}
