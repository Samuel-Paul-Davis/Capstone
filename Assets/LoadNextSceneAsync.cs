using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextSceneAsync : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "PlayerHitBox")
        {
            SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive); //magic number for testing
            Debug.Log("Load Next Scene Async");
            Destroy(this);
        }
    }
}
