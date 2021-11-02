using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class WaterOrbDialog : Puzzle
{

    public NPCConversation myConversation;
    // Start is called before the first frame update
    private void StartConversation()
    {
        if (unlocked == true)
        {
            ConversationManager.Instance.StartConversation(myConversation);
        }
    }
}
