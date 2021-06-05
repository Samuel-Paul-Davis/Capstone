using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    public bool isGamePaused = false;
    public KeyCode pauseMenuKey = KeyCode.Escape;
    [SerializeField]
    private GameObject GamePausePanel;

    // Start is called before the first frame update
    void Awake()
    {
        GamePausePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(pauseMenuKey))
        {
            if (isGamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        isGamePaused = true;
        Time.timeScale = 0;
        GamePausePanel.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Resume()
    {
        isGamePaused = false;
        Time.timeScale = 1;
        GamePausePanel.SetActive(false);
        Cursor.visible = false;
    }
}