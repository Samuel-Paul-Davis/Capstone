using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DoorPuzzleManager : MonoBehaviour
{
    [SerializeField]
    private PadeBehaviour[] pades;
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
        if (pades.All(x => x.PadeState == PuzzleState.On))
        {
            targetMove.z += -5;
        }

        transform.position = Vector3.Lerp(transform.position, targetMove, fallSpeed);
    }
}