using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardReader : MonoBehaviour
{
    public GameObject slot1_transform;
    public GameObject slot2_transform;

    private GameObject slot1_core;
    private GameObject slot2_core;


    /* Bugs:
     *      - As OnTriggerEnter runs on each FixedUpdate, the other object is being added twice
     */
    private void OnTriggerEnter(Collider other)
    {
        if (slot1_core != null && slot2_core != null)
            return;

        if (other.GetComponent<KeyCoreObject>()) {
            other.GetComponent<KeyCoreObject>().isMoving = false;
            other.GetComponent<KeyCoreObject>().isActive = false;

            if (slot1_core == null)
            {
                other.transform.position = slot1_transform.transform.position;
                slot1_core = other.gameObject;
            }
            else
            {
                other.transform.position = slot2_transform.transform.position;
                slot2_core = other.gameObject;
            }

            other.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
