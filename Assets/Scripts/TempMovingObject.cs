using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempMovingObject : MonoBehaviour
{
    Vector3 targetVector = Vector3.zero;
    Vector3 homeVector = Vector3.zero;
    public bool returnHome = false;

    // Start is called before the first frame update
    void Awake()
    {
        homeVector = transform.position;
        targetVector = new Vector3(homeVector.x, homeVector.y - 5, homeVector.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (returnHome)
            transform.position = Vector3.Lerp(transform.position, homeVector, 0.1f);
        else
            transform.position = Vector3.Lerp(transform.position, targetVector, 0.1f);
    }
}