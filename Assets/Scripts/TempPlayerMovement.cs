using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempPlayerMovement : MonoBehaviour
{
    GameObject gameObject = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if ( gameObject != null)
            {
                gameObject.GetComponent<AbstractObjectInteraction>().ObjectInteraction();
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Puzzle")
            gameObject = other.gameObject;
    }

    public void OnTriggerExit(Collider other)
    {
        if (gameObject == other.gameObject)
            gameObject = null;
    }
}