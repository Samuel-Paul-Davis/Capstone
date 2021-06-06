using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField]
    private PuzzleInteractionObject[] puzzleElements = new PuzzleInteractionObject[3];
    [SerializeField]
    private GameObject puzzleObjectState;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int total = puzzleElements.Length;
        int counting = 0;

        foreach (PuzzleInteractionObject interactionObject in puzzleElements)
        {
            if (interactionObject.puzzleState == PuzzleState.On)
                counting++;
        }

        if (counting == total)
            puzzleObjectState.GetComponent<PuzzleObjectManager>().UpdateMaterial(true);
        else
            puzzleObjectState.GetComponent<PuzzleObjectManager>().UpdateMaterial(false);
    }
}

public enum PuzzleState
{
    On,
    Off
}