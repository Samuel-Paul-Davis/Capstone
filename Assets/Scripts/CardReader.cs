using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardReader : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<KeyCoreObject>()) {
            other.GetComponent<KeyCoreObject>().isMoving = false;
            other.GetComponent<KeyCoreObject>().isActive = false;

            other.transform.position = transform.position;

            other.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
