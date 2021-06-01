using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ColourPuzzleManager : MonoBehaviour
{
    [SerializeField]
    private PuzzleInteractionObject[] puzzleElements = new PuzzleInteractionObject[3];
    private List<PuzzleInteractionObject> puzzleElementsEndState = new List<PuzzleInteractionObject>();
    [SerializeField]
    private GameObject puzzleObjectState;

    // Start is called before the first frame update
    void Awake()
    {
        List<int> intPuzzleElements = new List<int>();

        for (int i = 0; i < puzzleElements.Length; i++)
        {
            intPuzzleElements.Add(i);
        }

        intPuzzleElements = intPuzzleElements.OrderBy(x => Random.value).ToList();

        foreach(int i in intPuzzleElements)
        {
            puzzleElementsEndState.Add(puzzleElements[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        int total = puzzleElements.Length;
        int counting = 0;

        for (int i = 0; i < puzzleElements.Length; i++)
        {
            
        }

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