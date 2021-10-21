using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScannerBeam : MonoBehaviour
{
    public Material[] materials;
    public string targetTag;
    public GameObject[] ignoreList;

    private void Start()
    {
        foreach (Collider c in FindObjectsOfType<Collider>())
        {
            if (c.isTrigger)
            {
                Physics.IgnoreCollision(GetComponent<Collider>(), c);
            }
        }

        foreach (GameObject go in ignoreList)
        {
            Physics.IgnoreCollision(GetComponent<Collider>(), go.GetComponent<Collider>());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag) && other.GetComponentInChildren<MovableObject>() && other.GetComponentInChildren<Renderer>())
        {
            other.GetComponentInChildren<MovableObject>().Discover(materials);
        }
    }
}
