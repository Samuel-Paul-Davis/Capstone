using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScannerBeam : MonoBehaviour
{
    public Material[] materials;
    public string targetTag;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag) && other.gameObject.GetComponent<Renderer>())
        {
            other.GetComponent<MovableObject>().Discover(materials);
        }
    }
}
