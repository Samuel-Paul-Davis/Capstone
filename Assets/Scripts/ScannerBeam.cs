using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScannerBeam : MonoBehaviour
{
    public Material[] materials;
    public string targetTag;

    //private Dictionary<Renderer, Material[]> oldMats = new Dictionary<Renderer, Material[]>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag) && other.gameObject.GetComponent<Renderer>())
        {
            other.GetComponent<MovableObject>().Discover();
        }
    }

    /*private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(targetTag) && other.gameObject.GetComponent<Renderer>())
        {
            
        }
    }*/

    /*public void UnpaintAllTargets()
    {
        foreach (KeyValuePair<Renderer, Material[]> kvp in oldMats)
            kvp.Key.materials = oldMats[kvp.Key];

        oldMats.Clear();
    }*/
}
