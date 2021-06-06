using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadLevel : MonoBehaviour
{
    public void Reload()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }
}
