using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyReader : MonoBehaviour
{
    public bool unlocked = false;

    public GameObject slot1;
    public GameObject slot2;

    [SerializeField]
    private GameObject slot1_key;
    [SerializeField]
    private GameObject slot2_key;

    private void Start()
    {
        //if DRY could cry, oh my, why?
        if (slot1_key)
        {
            slot1_key.GetComponent<KeyCoreObject>().isActive = false;
            slot1_key.GetComponent<KeyCoreObject>().isMoving = false;
            slot1_key.GetComponent<Rigidbody>().isKinematic = true;

            slot1_key.transform.position = slot1.transform.position;
            slot1.GetComponent<Collider>().enabled = false;

            slot1_key.GetComponent<KeyCoreObject>().enabled = false;
            slot1_key.tag = "Untagged";
        }

        if (slot2_key)
        {
            slot2_key.GetComponent<KeyCoreObject>().isActive = false;
            slot2_key.GetComponent<KeyCoreObject>().isMoving = false;
            slot2_key.GetComponent<Rigidbody>().isKinematic = true;

            slot2_key.transform.position = slot2.transform.position;
            slot2.GetComponent<Collider>().enabled = false;

            slot2_key.GetComponent<KeyCoreObject>().enabled = false;
            slot2_key.tag = "Untagged";
        }
    }

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

        collision.GetContact(0).otherCollider.gameObject.GetComponent<KeyCoreObject>().enabled = false;
        collision.GetContact(0).otherCollider.gameObject.tag = "Untagged";
    }
}
