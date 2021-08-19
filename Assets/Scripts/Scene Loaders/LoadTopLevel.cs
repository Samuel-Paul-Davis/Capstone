using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadTopLevel : MonoBehaviour
{
    [SerializeField]
    private string TopLevelName;
    public void Load()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(TopLevelName);
    }
}
