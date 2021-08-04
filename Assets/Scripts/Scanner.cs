using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    public Material material;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Working");

        other.gameObject.GetComponent<Renderer>().material = material;
    }
}
