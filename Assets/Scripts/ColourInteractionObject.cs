using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourInteractionObject : AbstractObjectInteraction
{
    [SerializeField]
    public PuzzleState puzzleState = PuzzleState.Off;
    [SerializeField]
    public ColourObject colourObject;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void ObjectDeselectInteraction()
    {
        puzzleState = PuzzleState.Off;
    }

    public override void ObjectInteraction()
    {
        puzzleState = PuzzleState.On;
        GetComponentInParent<ColourPuzzleManager>().AddObjectToActive(this);
        Debug.Log("Yep");
    }
}