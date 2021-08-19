using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadeBehaviour : MonoBehaviour
{
    public PuzzleState PadeState { get; set; }

    // Start is called before the first frame update
    void Awake()
    {
        PadeState = PuzzleState.Off;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Puzzle")
            PadeState = PuzzleState.On;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Puzzle")
            PadeState = PuzzleState.Off;
    }
}