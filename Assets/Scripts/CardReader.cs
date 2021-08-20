using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardReader : MonoBehaviour
{
    public GameObject slot1;
    public GameObject slot2;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Can touch this!");
    }

    public void Insert(Collider collider, GameObject slot)
    {
        collider.gameObject.transform.position = slot.transform.position;
    }
}
