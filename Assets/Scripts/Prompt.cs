using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class Prompt : Puzzle
{
    [SerializeField]
    private bool waterOrb = false;
    public NPCConversation myConversation;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && waterOrb == true)
        {
            GameObject.Destroy(gameObject);
            Debug.Log("destroyed");
            unlocked = true;
            waterOrb = false;
            if (unlocked == true && waterOrb == false)
            {
                ConversationManager.Instance.StartConversation(myConversation);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            waterOrb = true;
            Debug.Log("touched");
            //MessagePanel.SetActive(true);

        }

        else
        {
            //MessagePanel.SetActive(false);
        }
    }
}
