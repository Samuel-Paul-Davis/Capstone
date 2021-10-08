using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuBehaviour : MonoBehaviour
{
    [SerializeField]
    private string MainMenuName = "Menu";
    [SerializeField]
    private string DesertLevelName = "Desert Start Area";
    [SerializeField]
    private string TopLevelName = "Top Level";
    [SerializeField]
    private string BottemLevelName = "Lower Level";

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(MainMenuName);
    }
    public void LoadDesertLevel()
    {
        SceneManager.LoadScene(DesertLevelName);
    }
    public void LoadTopLevel()
    {
        SceneManager.LoadScene(TopLevelName);
    }
    public void LoadBottemLevel()
    {
        SceneManager.LoadScene(BottemLevelName);
    }

    public void Reload()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }
}