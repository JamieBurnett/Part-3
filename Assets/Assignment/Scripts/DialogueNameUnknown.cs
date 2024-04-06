using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueNameUnknown : Dialogue
{
    public string namePlaceholder;
    private string[] nameHolder;
    private int counter = 0;
    
    // Start is called before the first frame update
    public void Mixup()
    {
        counter = 0;
        nameHolder = new string[name.Length];
        foreach(string i in name)
        {
            nameHolder[counter] = i;
            name[counter] = namePlaceholder;
            counter += 1;
        }
    }
    public void LearnName()
    {
        counter = 0;
        foreach (string i in name)
        {
            name[counter] = nameHolder[counter];
            counter += 1;
        }
    }
    override public void displayMe()
    {
        DialogueManager.diaManager.StartDialogue(this);
    }

}
