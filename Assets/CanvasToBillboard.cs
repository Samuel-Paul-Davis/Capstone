using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasToBillboard : MonoBehaviour
{
    [Tooltip("Causes canvas to always face camera")]
    public Transform cam;

    private void LateUpdate()
    {
        transform.LookAt(transform.position + cam.forward);
    }
}
    