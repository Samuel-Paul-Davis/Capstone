using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DoorPuzzleManager : MonoBehaviour
{
    [SerializeField]
    //private PadeBehaviour[] pades;
    private WeightTrigger[] pades;
    [SerializeField]
    private float fallSpeed;
    private Vector3 targetMove;

    // Start is called before the first frame update
    void Awake()
    {
        targetMove = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //this is not a proper fix; BUG: pades are sometimes null and sometimes not
        if (pades.All(x => x == null))
            return;

        //if (pades.All(x => x.PadeState == PuzzleState.On))
        //if (pades.All(x => x.IsTriggered == true))
        if (pades.All(x => x.State == PuzzleState.On))
        {
            targetMove.z += -5;
        }

        transform.position = Vector3.Lerp(transform.position, targetMove, fallSpeed);
    }
}