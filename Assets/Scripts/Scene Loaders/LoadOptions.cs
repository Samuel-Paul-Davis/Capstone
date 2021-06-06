using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadOptions : MonoBehaviour
{
    public void Load()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }
}
