using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInteractionSystem : MonoBehaviour
{
    const int MOUSELEFTCLICK = 0;
    const int MOUSERIGHTCLICK = 1;
    private GameObject currentObject;
    public bool isMouseActive { get; set; }

    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isMouseActive)
        {
            if (Input.GetMouseButton(MOUSELEFTCLICK))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.rigidbody != null)
                    {
                        if (hit.rigidbody.gameObject.tag == "Object")
                        {
                            currentObject = hit.rigidbody.gameObject;
                            currentObject.GetComponent<AbstractObjectInteraction>().ObjectInteraction();
                        }                           
                    }
                }
            }
            
            if (Input.GetMouseButton(MOUSERIGHTCLICK))
            {
                currentObject = null;
            }
        }        
    }
}