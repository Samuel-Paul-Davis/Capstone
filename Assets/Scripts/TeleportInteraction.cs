using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportInteraction : AbstractObjectInteraction
{
    [SerializeField]
    private string NextSceneName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void ObjectDeselectInteraction()
    {
        
    }

    public override void ObjectInteraction()
    {
        SceneManager.LoadScene(NextSceneName);
    }
}