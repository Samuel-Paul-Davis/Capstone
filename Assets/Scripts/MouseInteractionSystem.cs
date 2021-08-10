using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TheFirstPerson;
using UnityEngine;

public class MouseInteractionSystem : MonoBehaviour
{
    const int MOUSELEFTCLICK = 0;
    const int MOUSERIGHTCLICK = 1;
    private GameObject currentObject;
    [SerializeField]
    public bool isMouseActive = false;
    private List<GameObject> targetList = new List<GameObject>();

    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown(GetComponent<FPSController>().GetTargetingBtn()))
        {
            MovableObject movableObject;
            List<GameObject> tempObjectList = GameObject.FindGameObjectsWithTag("Puzzle").ToList();
            targetList.Clear();

            foreach (GameObject gameObject in tempObjectList)
            {
                if (gameObject.GetComponent<Renderer>().isVisible && gameObject.TryGetComponent<MovableObject>(out movableObject))
                {
                    targetList.Add(gameObject);
                }
            }
            foreach (GameObject gmObject in targetList)
                Debug.Log(gmObject.name);
        }
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
            if (Input.GetMouseButtonUp(MOUSELEFTCLICK))
            {
                if (currentObject != null)
                    currentObject.GetComponent<AbstractObjectInteraction>().ObjectDeselectInteraction();
                currentObject = null;
            }
        }
    }
}