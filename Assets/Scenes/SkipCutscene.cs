using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipCutscene : MonoBehaviour
{
    [SerializeField]
    private string SkipTo;
    public void Load()
    {
        SceneManager.LoadScene(SkipTo, LoadSceneMode.Single);
    }
}
