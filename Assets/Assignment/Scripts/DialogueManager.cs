using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public static bool playerInDialogue;
    public static DialogueManager diaManager;
    public GameObject dialogueBox;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    private Queue<string> sentences;
    private int counter;
    private string[] names;
    public Color32[] colours;
    private Color32[] colourStorage;
    private int colourCounter;

    // Start is called before the first frame update
    void Start()
    {
        diaManager = FindObjectOfType<DialogueManager>();
        nameText.text = "";
        dialogueText.text = "";
        sentences = new Queue<string>();
        dialogueBox.SetActive(false);
        counter = 0;
        colourCounter =0;
        colourStorage = new Color32[colours.Length];
        foreach (Color i in colours)
        {
            colourStorage[counter] = i;
            counter += 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            EndDialogue();
        }
        if (Input.GetButtonDown("Next"))
        {
            DisplayNextSentence();
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        if (!playerInDialogue)
        {
            dialogueBox.SetActive(true);

            playerInDialogue = true;

            counter = 0;
            Debug.Log("Starting conversation with... " + dialogue.name[counter]);

            names = dialogue.name;

            sentences.Clear();

            foreach (string sentence in dialogue.sentences)
            {

                sentences.Enqueue(sentence);

            }
            DisplayNextSentence();
        }

       
    }

    public void StartDialogueUnknown(DialogueNameUnknown dialogue)
    {
        if (!playerInDialogue)
        {
            dialogueBox.SetActive(true);

            playerInDialogue = true;

            counter = 0;
            Debug.Log("Starting conversation with... " + dialogue.name[counter]);

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
        nameText.color = colours[colourCounter];
        dialogueText.color = colours[colourCounter];
        colourCounter += 1;
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        nameText.text = names[counter];
        counter += 1;
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
    
    public void DialogueEnd()
    {
        colourCounter = 0;
        counter = 0;
        foreach (Color32 i in colourStorage)
        {
            colours[counter] = i;
            counter += 1;
        }
        StopAllCoroutines();
        dialogueText.text = "";
        nameText.text = "";
        dialogueBox.SetActive(false);
    }

    public static void EndDialogue()
    {
        DialogueManager.playerInDialogue = false;
        Debug.Log("end of conversation");
        diaManager.DialogueEnd();
    }

}
