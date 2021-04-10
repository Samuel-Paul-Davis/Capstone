using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadPrevScene : MonoBehaviour
{
    private int count;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "PlayerHitBox")
        {
            count++;

            if (count > 1)
            {
                SceneManager.LoadScene(0, LoadSceneMode.Additive); //magic number for testing
                //Debug.Log("Load Prev Scene " + count);
            }
        }
    }
}
