using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverDoor : MonoBehaviour
{
    public LeverObject lever;

    private Vector3 openPosition;
    private Vector3 closedPosition;

    private void Awake()
    {
        closedPosition = transform.position;

        openPosition = transform.position;
        openPosition.x -= 1;
    }

    private void Update()
    {
        Debug.Log("Door signal: " + lever.isOn);

        if (lever.isOn)
            Open();
        else
            Close();
    }

    private void Open()
    {
        if (transform.position != openPosition)
            transform.position = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
    }

    private void Close()
    {
        if (transform.position != closedPosition)
            transform.position = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
    }
}
