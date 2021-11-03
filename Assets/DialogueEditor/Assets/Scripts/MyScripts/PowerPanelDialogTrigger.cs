using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class PowerPanelDialogTrigger : MonoBehaviour
{
    public NPCConversation myConversation;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ConversationManager.Instance.StartConversation(myConversation);
            GameObject.Destroy(gameObject);
        }
    }
}
