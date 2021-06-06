using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayPauseOptions : MonoBehaviour
{
    public GameObject optionPanel;
    private GameObject callingObject;

    private void Awake()
    {
        optionPanel.SetActive(false);
    }


    public void Show(GameObject caller)
    {
        optionPanel.SetActive(true);
        caller.SetActive(false);
        callingObject = caller;
    }

    public void Hide()
    {
        callingObject.SetActive(true);
        optionPanel.SetActive(false);
    }
}
