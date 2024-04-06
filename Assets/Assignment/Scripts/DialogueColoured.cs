using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueColoured :Dialogue
{
    // Start is called before the first frame update
    private int counter;
    public Color32[] colours;

    override public void displayMe()
    {
        if (!DialogueManager.playerInDialogue)
        {
            counter = 0;

            foreach (Color32 i in colours)
            {
                DialogueManager.diaManager.colours[counter] = i;
                counter += 1;
            }
            DialogueManager.diaManager.StartDialogue(this);
        }
        

    }
}
