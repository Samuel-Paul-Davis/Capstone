using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyReaderSingle : MonoBehaviour
{
    public bool unlocked = false;

    public GameObject slot1;

    [SerializeField]
    private GameObject slot1_key;

    private void Update()
    {
        if (slot1_key != null)
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

        collision.GetContact(0).thisCollider.enabled = false;

        collision.GetContact(0).otherCollider.gameObject.GetComponent<KeyCoreObject>().enabled = false;
        collision.GetContact(0).otherCollider.gameObject.tag = "Untagged";
    }
}
