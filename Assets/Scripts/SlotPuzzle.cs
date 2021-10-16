using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotPuzzle : Puzzle
{
    public List<GameObject> slots;

    [SerializeField]
    //protected GameObject[] slot_parts;

    protected void Start()
    {
        Transform[] children = transform.GetComponentsInChildren<Transform>();

        foreach (Transform child in children)
            if (child != transform)
                slots.Add(child.gameObject);

        //slot_parts = new GameObject[slots.Count];
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<SlotPartObject>() != null)
        {
            bool sucess = false;
            for (int i=0;i<transform.childCount;i++)
            {
                if (transform.GetChild(i).gameObject.activeInHierarchy && transform.GetChild(i).childCount == 0) {
                    other.transform.SetParent(transform.GetChild(i), false);
                    sucess = true;
                }

                if (!sucess)
                    return;
            }

            other.GetComponent<Rigidbody>().isKinematic = true;
            other.transform.localPosition = Vector3.zero;
            other.transform.localRotation = Quaternion.identity;

            //slot_parts[slots.IndexOf(gameObject)] = other.gameObject;
        }
    }
}
