using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardReader : MonoBehaviour
{
    public GameObject slot1;
    public GameObject slot2;

    private List<GameObject> cores = new List<GameObject>() { null, null };

    /* Bugs:
     *      - As OnTriggerEnter runs on each FixedUpdate, the other object is being added twice
     */
    private void OnTriggerEnter(Collider other)
    {
        if (cores[0] != null && cores[1] != null)
            return;

        if (other.GetComponent<KeyCoreObject>())
        {
            int i = 0;
            /*while (i < cores.Count) //infinite loop with (Fixed)Update()
            {
                Debug.Log("Line 25");
                if (cores[0] == null && cores[1] == null)
                    break;

                Debug.Log("Line 28");

                if (cores[i].GetComponent<KeyCoreObject>().id == other.GetComponent<KeyCoreObject>().id) {
                    return;
                }
            }*/

            Debug.Log("Line 33");
        
            other.GetComponent<KeyCoreObject>().isMoving = false;
            other.GetComponent<KeyCoreObject>().isActive = false;

            if (cores[0] == null)
            {
                other.transform.position = slot1.transform.position;
                cores[0] = other.gameObject;
            }
            else
            {
                other.transform.position = slot2.transform.position;
                cores[1] = other.gameObject;
            }

            Debug.Log("Line 49");

            other.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
