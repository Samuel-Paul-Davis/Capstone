using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DesertStartLoader : MonoBehaviour
{
    private void OnEnable()
    {
        SceneManager.LoadScene("Desert Start Area", LoadSceneMode.Single);
    }
}
