using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class CutsceneEnter : MonoBehaviour
{
    public GameObject thePlayer;
    public GameObject cutsceneCam;
    public NPCConversation myConversation;

    private void OnTriggerEnter(Collider other)
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        cutsceneCam.SetActive(true);
        thePlayer.SetActive(false);
        StartCoroutine(FinishCut());
        
    }

    IEnumerator FinishCut()
    {
        yield return new WaitForSeconds(8);
        thePlayer.SetActive(true);
        cutsceneCam.SetActive(false);
        ConversationManager.Instance.StartConversation(myConversation);
    }
}
