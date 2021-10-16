using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotPuzzle : Puzzle
{
    public List<GameObject> slots;

    [SerializeField]
    protected GameObject[] slot_parts;

    protected void Start()
    {
        Transform[] children = transform.GetComponentsInChildren<Transform>();

        foreach (Transform child in children)
            if (child != transform)
                slots.Add(child.gameObject);

        slot_parts = new GameObject[slots.Count];
    }

    protected void OnCollisionEnter(Collision collision)
    {
        //collision.GetContact(0).otherCollider.gameObject.GetComponent<SlotPartObject>().isActive = false;
        //collision.GetContact(0).otherCollider.gameObject.GetComponent<SlotPartObject>().isMoving = false;
        //collision.GetContact(0).otherCollider.attachedRigidbody.isKinematic = true;

        //collision.GetContact(0).otherCollider.transform.position = collision.GetContact(0).thisCollider.transform.position;
        //collision.GetContact(0).otherCollider.transform.rotation = collision.GetContact(0).thisCollider.transform.rotation;

        if (collision.GetContact(0).otherCollider.GetComponent<SlotPartObject>() != null && collision.GetContact(0).thisCollider.transform.childCount == 0 /*&& collision.GetContact(0).otherCollider.transform.parent == null*/)
        {
            collision.GetContact(0).otherCollider.transform.SetParent(collision.GetContact(0).thisCollider.transform, false);
            collision.GetContact(0).otherCollider.transform.localPosition = Vector3.zero;
            collision.GetContact(0).otherCollider.transform.localRotation = Quaternion.identity;

            slot_parts[slots.IndexOf(collision.GetContact(0).thisCollider.gameObject)] = collision.GetContact(0).otherCollider.gameObject;
        }

        //collision.GetContact(0).thisCollider.enabled = false;

        //collision.GetContact(0).otherCollider.gameObject.GetComponent<SlotPartObject>().enabled = false;
        //collision.GetContact(0).otherCollider.gameObject.tag = "Untagged";
    }
}
