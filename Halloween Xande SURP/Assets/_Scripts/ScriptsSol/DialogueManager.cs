using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    public Animator animator;

    private string character1Name;
    private string character2Name;
    private bool isCharacter1Turn = true;

    private Queue<string> sentences;

    DialogueTrigger _sender;

    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue, DialogueTrigger sender)
    {
        _sender = sender;
        animator.SetBool("IsOpen", true);

    
        character1Name = dialogue.character1Name;
        character2Name = dialogue.character2Name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();

    
        if (isCharacter1Turn)
        {
            nameText.text = character1Name;
        }
        else
        {
            nameText.text = character2Name;
        }

        isCharacter1Turn = !isCharacter1Turn;  
        dialogueText.text = sentence;

        StopAllCoroutines();
        StartCoroutine(TypeLetters(sentence));
    }

    IEnumerator TypeLetters(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        _sender.OnDialogueFinish.Invoke();
        _sender = null;
    }
}
