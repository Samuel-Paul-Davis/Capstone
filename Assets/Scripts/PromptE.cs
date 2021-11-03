using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PromptE : MonoBehaviour
{

    public GameObject messagePanel;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            messagePanel.SetActive(true);
        }

        else messagePanel.SetActive(false);
    }

    private void OnTriggerExit(Collider other)
    {
        messagePanel.SetActive(false);
        GameObject.Destroy(gameObject);
    }
}
