using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerColoured : MonoBehaviour
{
    public DialogueColoured dialogue;
    public bool loop;
    public Dialogue[] postTalkingDialogue;

    private bool havetalked;
    private int dialogueCounter;
    // Start is called before the first frame update
    void Start()
    {
        dialogueCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void sendDialogue()
    {
        if (!havetalked)
        {
            dialogue.displayMe();
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
