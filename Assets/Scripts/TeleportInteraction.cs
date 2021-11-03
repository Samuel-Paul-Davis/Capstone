using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DialogueEditor;

public class TeleportInteraction : AbstractObjectInteraction
{
    [SerializeField]
    private string NextSceneName;

    public GameObject messagePanel;

    private AudioSource audioSource;

    private void Start()
    {
        if (TryGetComponent<AudioSource>(out audioSource))
            Debug.LogWarning("No Audio Source on: " + name);
    }

    public override void ObjectDeselectInteraction()
    {
        
    }

    public override void ObjectInteraction()
    {
        audioSource.Play();
        SceneManager.LoadScene(NextSceneName);
    }
}