using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UnloadScene : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "PlayerHitBox")
        {
            if (SceneManager.GetSceneAt(1).name == "Level2") SceneManager.UnloadSceneAsync("Level2");
            if (SceneManager.GetSceneAt(1).name == "Level2Long") SceneManager.UnloadSceneAsync("Level2Long");
            if (SceneManager.GetSceneAt(1).name == "Level2IJob") SceneManager.UnloadSceneAsync("Level2IJob");
            Debug.Log("Unload Prev Scene");
            Destroy(this);
        }
    }
}
