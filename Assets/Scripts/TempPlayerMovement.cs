using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempPlayerMovement : MonoBehaviour
{
    public float movement = 0.05f;
    bool isArea = false;
    GameObject gameObject = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x + 1, transform.position.y, transform.position.z), movement);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x - 1, transform.position.y, transform.position.z), movement);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isArea && gameObject != null)
            {
                gameObject.GetComponent<InteractableObject>().ObjectInteraction();
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        isArea = true;
        gameObject = other.gameObject;
    }

    public void OnTriggerExit(Collider other)
    {
        isArea = false;
        gameObject = null;
    }
}