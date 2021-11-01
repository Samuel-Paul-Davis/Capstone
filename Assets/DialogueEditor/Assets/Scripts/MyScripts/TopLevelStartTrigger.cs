using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;


public class TopLevelStartTrigger : MonoBehaviour
{

    public NPCConversation myConversation;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ConversationManager.Instance.StartConversation(myConversation);
            GameObject.Destroy(gameObject);
        }
    }
}
