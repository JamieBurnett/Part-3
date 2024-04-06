using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnknownNameDialogueTrigger : MonoBehaviour
{
    public DialogueNameUnknown dialogue;
    public bool loop;
    public Dialogue[] postTalkingDialogue;

    private bool havetalked;
    private int dialogueCounter;
    private bool conversationStarted;
    private bool nameLearned;

    // Start is called before the first frame update
    void Start()
    {
        dialogueCounter = 0;
        dialogue.Mixup();
        conversationStarted = false;
        nameLearned = false;
}

    // Update is called once per frame
    void Update()
    {
        if (conversationStarted && !DialogueManager.playerInDialogue && !nameLearned)
        {
            dialogue.LearnName();
            nameLearned = true;
        }
    }

    public void sendDialogue()
    {
        if (!havetalked)
        {
            dialogue.displayMe();
            conversationStarted = true;
            havetalked = !loop;
        }
        else
        {
            postTalkingDialogue[dialogueCounter].displayMe();
            dialogueCounter += 1;
            if (dialogueCounter >= postTalkingDialogue.Length)
            {
                dialogueCounter = 0;
            }
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.tag == "Player" && Input.GetButton("Talk") && !DialogueManager.playerInDialogue)
        {
            sendDialogue();
        }
    }
}
