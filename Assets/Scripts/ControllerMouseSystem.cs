using System.Collections;
using System.Collections.Generic;
using TheFirstPerson;
using UnityEngine;

public class ControllerMouseSystem : MonoBehaviour
{
    [SerializeField]
    private FPSController fpsController;
    [SerializeField]
    private int sensitivity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {        
        //if (Cursor.lockState == CursorLockMode.Confined)
        //{
        //    transform.position = Input.mousePosition;
        //    Cursor.visible = false;
        //}
        if (Input.GetAxisRaw(fpsController.GetControllerHorizontal()) > 0 || Input.GetAxisRaw(fpsController.GetControllerVertical()) > 0)
        {
            Debug.Log(new Vector3(Input.GetAxisRaw(fpsController.GetControllerHorizontal()), Input.GetAxisRaw(fpsController.GetControllerVertical())));
            //Vector3.MoveTowards(transform.position, new Vector3(Input.GetAxis(fpsController.GetControllerHorizontal()), Input.GetAxis(fpsController.GetControllerVertical())), 2);
            Vector3 translation = new Vector3(Input.GetAxis("MouseHorizontal"), Input.GetAxis("MouseVertical"));
            transform.Translate(translation.normalized * sensitivity);
        }
    }
}