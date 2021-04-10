using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeAsync : MonoBehaviour
{
    private GameObject exit;

    private void OnTriggerExit(Collider collider)
    {
        exit = GameObject.Find("Exit");

        if (exit.GetComponent<LoadNextSceneAsync>()) Destroy(exit.GetComponent<LoadNextSceneAsync>());
        if (exit.GetComponent<LoadNextScene>()) Destroy(exit.GetComponent<LoadNextScene>());
        if (exit.GetComponent<LoadLongScene>()) Destroy(exit.GetComponent<LoadLongScene>());
        if (exit.GetComponent<LoadJobScene>()) Destroy(exit.GetComponent<LoadJobScene>());

        exit.AddComponent<LoadNextSceneAsync>();
    }
}
