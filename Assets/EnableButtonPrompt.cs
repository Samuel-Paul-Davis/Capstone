using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EnableButtonPrompt : MonoBehaviour
{
    public GameObject displayObject;
    public bool display = true;
    public string textToDisplay;
    public KeyCode key;

    private TextMeshProUGUI text;
    private bool currentlyDisplayed;
    private void Start()
    {
        text = displayObject.GetComponentInChildren<TextMeshProUGUI>();

        if (!text)
        {
            Debug.LogWarning("TextMeshPro not found");
        }

    }

    private void ToggleText(bool activate)
    {
        displayObject.SetActive(activate);
        currentlyDisplayed = activate;
    }

    private void Update()
    {
        if (currentlyDisplayed && Input.GetKeyDown(key))
        {
            ToggleText(false);
            display = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        print("Active");
        if (display && other.CompareTag("Player"))
        {
            text.text = textToDisplay;
            ToggleText(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        print("Not");
        if (other.CompareTag("Player"))
        {
            ToggleText(false);
        }
    }
}
