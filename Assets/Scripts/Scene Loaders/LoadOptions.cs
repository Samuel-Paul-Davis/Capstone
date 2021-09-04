using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadOptions : MonoBehaviour
{
    public string LevelName;
    public void Load()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Lower Level");
    }
}
