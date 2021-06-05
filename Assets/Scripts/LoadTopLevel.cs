using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadTopLevel : MonoBehaviour
{
    public void Load()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}
