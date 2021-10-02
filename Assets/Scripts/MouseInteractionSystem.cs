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
            List<GameObject> newTargetList = new List<GameObject>();

            foreach (GameObject gameObject in tempObjectList)
            {
                RaycastHit hit;

                if (Physics.Raycast(transform.position, (gameObject.transform.position - transform.position), out hit) && gameObject.GetComponent<Renderer>().isVisible)
                {
                    if (hit.collider.gameObject.tag == "Puzzle")
                    {
                        newTargetList.Add(gameObject);
                    }
                }
            }

            tempObjectList.Clear();

            foreach (GameObject gameObject in targetList)
                if (!newTargetList.Contains(gameObject))
                    tempObjectList.Add(gameObject);

            tempObjectList.ForEach(tempObject => targetList.Remove(tempObject));

            foreach (GameObject gameObject in newTargetList)
                if (!targetList.Contains(gameObject))
                    targetList.Add(gameObject);

            string tempString = "Raycast & IsVisible: ";
            targetList.ForEach(gameObject => tempString += gameObject.name + ", ");
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