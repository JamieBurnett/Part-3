using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string[] name;
    [TextArea(4, 12)]
    public string[] sentences;
    virtual public void displayMe()
    {
        DialogueManager.diaManager.StartDialogue(this);
    }


}


