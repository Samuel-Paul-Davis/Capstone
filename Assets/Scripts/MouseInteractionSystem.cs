using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInteractionSystem : MonoBehaviour
{
    const int MOUSELEFTCLICK = 0;
    const int MOUSERIGHTCLICK = 1;
    private GameObject currentObject;
    [SerializeField]
    public bool isMouseActive = false;

    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isMouseActive)
        {
            if (Input.GetMouseButtonDown(MOUSELEFTCLICK))
            {
                
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.rigidbody != null)
                    {
                        if (hit.rigidbody.gameObject.tag == "Puzzle")
                        {
                            currentObject = hit.rigidbody.gameObject;
                            currentObject.GetComponent<AbstractObjectInteraction>().ObjectInteraction();
                        }
                    }
                }
            }
            
            if (Input.GetMouseButtonDown(MOUSERIGHTCLICK))
            {
                if (currentObject != null)
                    currentObject.GetComponent<AbstractObjectInteraction>().ObjectDeselectInteraction();
                currentObject = null;
            }
        }
    }
}