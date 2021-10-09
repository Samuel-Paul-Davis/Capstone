using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int collectLayer = 6;
    public int receiverLayer = 7;

    private static List<GameObject> inventory = new List<GameObject>();

    public List<GameObject> GetInventory() { 
        return inventory;
    }

    public void Collect(GameObject gameObject)
    {
        inventory.Add(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == collectLayer)
        {
            Collect(other.gameObject);
            other.gameObject.layer = 0;
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.layer == receiverLayer)
        {
            foreach (GameObject item in inventory)
            {
                item.transform.position = other.transform.position;
                item.SetActive(true);
            }
        }
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.GetContact(0).otherCollider.gameObject.layer)

        if (collision.GetContact(0).otherCollider.gameObject.layer == collectLayer)
        {
            collision.GetContact(0).otherCollider.gameObject.layer = 0;
            collision.GetContact(0).otherCollider.gameObject.SetActive(false);
            Collect(collision.GetContact(0).otherCollider.gameObject);
        }

        if (collision.GetContact(0).otherCollider.isTrigger)
        {
            foreach (GameObject item in inventory)
            {
                item.transform.position = collision.GetContact(0).point;
                item.SetActive(true);
            }
        }
    }*/
}
