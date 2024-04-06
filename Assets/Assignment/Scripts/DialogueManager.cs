using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    static bool playerInDialogue;
    public GameObject dialogueBox;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    private Queue<string> sentences;
    private int nameCounter;
    private string[] names;

    // Start is called before the first frame update
    void Start()
    {
        nameText.text = "";
        dialogueText.text = "";
        sentences = new Queue<string>();
        dialogueBox.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartDialogue(Dialogue dialogue)
    {
        if (!playerInDialogue)
        {
            dialogueBox.SetActive(true);

            playerInDialogue = true;

            nameCounter = 0;
            Debug.Log("Starting conversation with... " + dialogue.name[nameCounter]);

            names = dialogue.name;

            sentences.Clear();

            foreach (string sentence in dialogue.sentences)
            {

                sentences.Enqueue(sentence);

            }
            DisplayNextSentence();
        }

       
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        nameText.text = names[nameCounter];
        nameCounter += 1;
        Debug.Log(sentence);
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.01f);
        }
    }
    
    public void EndDialogue()
    {
        playerInDialogue = false;
        Debug.Log("end of conversation");

        StopAllCoroutines();
        dialogueText.text = "";
        nameText.text = "";
        dialogueBox.SetActive(false);
    }

}
