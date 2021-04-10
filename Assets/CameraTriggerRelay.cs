using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTriggerRelay : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        transform.parent.parent.GetComponent<CameraManager>().GetCameraTrigger(this); //this needs to be more robust
    }
}
