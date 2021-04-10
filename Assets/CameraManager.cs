using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public List<Camera> cameras;
    private Camera curCamera;
    private Camera prevCamera;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Camera c in cameras)
            c.enabled = false;

        curCamera = cameras[0];
        cameras[0].enabled = true;
    }

    public void GetCameraTrigger(Component trigger)
    {
        prevCamera = curCamera;
        curCamera = trigger.gameObject.transform.parent.GetComponent<Camera>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        //Debug.Log(cameras.IndexOf(curCamera));
        if (prevCamera) prevCamera.enabled = false;
        curCamera.enabled = true;
    }
}
