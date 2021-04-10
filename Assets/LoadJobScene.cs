using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadJobScene : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "PlayerHitBox")
        {
            SceneManager.LoadScene(3, LoadSceneMode.Additive); //magic number for testing
            Debug.Log("Load Next Scene");
            Destroy(this);
        }
    }
}
