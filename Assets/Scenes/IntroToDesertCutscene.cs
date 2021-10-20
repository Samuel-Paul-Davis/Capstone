using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroToDesertCutscene : MonoBehaviour
{
    private void OnEnable()
    {
        SceneManager.LoadScene("Desert Intro Cutscene", LoadSceneMode.Single);
    }
}
