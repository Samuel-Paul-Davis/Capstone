using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Jobs;
using Unity.Collections; //rm if no NativeContainer

//doesn't work because LoadScene needs to be called from the main thread
public struct LoadSceneJob : IJob
{
    public void Execute()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Additive); //magic number for testing
    }
}

public class LoadNextSceneIJob : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "PlayerHitBox")
        {
            LoadSceneJob loadSceneJob = new LoadSceneJob();
            JobHandle jh = loadSceneJob.Schedule();
            Debug.Log("Load Next Scene");
            Destroy(this);
        }
    }
}
