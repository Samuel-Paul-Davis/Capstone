using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PromptE : MonoBehaviour
{

    private void Update()
    {

    }

    public GameObject messagePanel;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            messagePanel.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        GameObject.Destroy(gameObject);
    }
}
