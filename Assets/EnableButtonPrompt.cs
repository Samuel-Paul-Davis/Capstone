using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EnableButtonPrompt : MonoBehaviour
{
    public GameObject displayObject;
    public bool display = true;
    public string textToDisplay;

    private TextMeshProUGUI text;
    private void Start()
    {
        text = displayObject.GetComponentInChildren<TextMeshProUGUI>();

        if (!text)
        {
            Debug.LogWarning("TextMeshPro not found");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (display && other.tag == "Player")
        {
            text.text = textToDisplay;
            displayObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            displayObject.SetActive(false);
        }
    }
}
