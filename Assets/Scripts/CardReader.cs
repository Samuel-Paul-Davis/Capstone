using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardReader : MonoBehaviour
{
    public GameObject slot1;
    public GameObject slot2;

    public bool unlocked = false;

    private GameObject slot1_key;
    private GameObject slot2_key;

    private void Update()
    {
        if (slot1_key != null && slot2_key != null)
            unlocked = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        collision.GetContact(0).otherCollider.gameObject.GetComponent<KeyCoreObject>().isActive = false;
        collision.GetContact(0).otherCollider.gameObject.GetComponent<KeyCoreObject>().isMoving = false;
        collision.GetContact(0).otherCollider.attachedRigidbody.isKinematic = true;

        collision.GetContact(0).otherCollider.transform.position = collision.GetContact(0).thisCollider.transform.position;

        if (collision.GetContact(0).thisCollider.gameObject == slot1)
            slot1_key = collision.GetContact(0).otherCollider.gameObject;

        if (collision.GetContact(0).thisCollider.gameObject == slot2)
            slot2_key = collision.GetContact(0).otherCollider.gameObject;

        collision.GetContact(0).thisCollider.enabled = false;
    }
}
