using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ColourPuzzleManager : MonoBehaviour
{
    [SerializeField]
    private ColourInteractionObject[] puzzleElements = new ColourInteractionObject[3];
    private List<ColourInteractionObject> puzzleElementsActiveState = new List<ColourInteractionObject>();
    private List<ColourInteractionObject> puzzleElementsEndState = new List<ColourInteractionObject>();
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

        ColourPuzzleExtensions.Shuffle(intPuzzleElements);

        foreach(int i in intPuzzleElements)
        {
            Debug.Log(i);
            puzzleElementsEndState.Add(puzzleElements[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        bool orderCorrect = true;

        for (int i = 0; i < puzzleElementsEndState.Count; i++)
        {
            if (puzzleElementsActiveState.Count > i)
            {
                if (puzzleElementsEndState[i] != puzzleElementsActiveState[i])
                {
                    orderCorrect = false;
                    break;
                }
            }
            else
            {
                orderCorrect = false;
                break;
            }
                
        }

        if (orderCorrect)
            puzzleObjectState.GetComponent<PuzzleObjectManager>().UpdateMaterial(true);
        else
            puzzleObjectState.GetComponent<PuzzleObjectManager>().UpdateMaterial(false);
    }

    public void AddObjectToActive(ColourInteractionObject colourObject)
    {
        puzzleElementsActiveState.Add(colourObject);
    }

    
}

public enum ColourObject
{
    one,
    two,
    three
}

public static class ColourPuzzleExtensions
{
    public static void Shuffle<T>(this IList<T> list)
    {
        System.Random rng = new System.Random();
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}