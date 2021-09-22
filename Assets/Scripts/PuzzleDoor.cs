using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleDoor : MonoBehaviour
{
    public Puzzle caller;
    public Transform targetPosition;
    
    /*[Header("Direction")]
    public bool x = false;
    public bool y = false;
    public bool z = false;*/

    private Vector3 openPosition;
    private Vector3 closedPosition;

    private void Start()
    {
        closedPosition = transform.position;

        openPosition = targetPosition.position;

        //openPosition = transform.position;
        //openPosition = transform.localPosition;

        /*if (x)
            openPosition.x -= (transform.localScale.x * 1);

        if (y)
            openPosition.y -= (transform.localScale.y * 1);

        if (z)
            openPosition.z -= (transform.localScale.z * 1); //BUG:
                                                            //      - if scale value is < 1 it will start performing percentages? Or times by zero if == 0?
                                                            //      - if scale is == 1 then object won't move
        */
                                                                    
    }

    private void Update()
    {
        if (caller.unlocked)
            Open();
        else
            Close();
    }

    private void Open()
    {
        if (transform.position != openPosition)
            transform.position = openPosition;
     }

    private void Close()
    {
        if (transform.position != closedPosition)
            transform.position = closedPosition;
    }
}
