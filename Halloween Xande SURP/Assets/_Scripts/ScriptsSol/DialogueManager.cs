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
    private bool isCharacter1Turn = true;  // Controla a alternância entre os personagens

    private Queue<string> sentences;

    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);

        // Define os nomes dos personagens com base no diálogo passado
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

        // Alterna entre os nomes dos personagens
        if (isCharacter1Turn)
        {
            nameText.text = character1Name;
        }
        else
        {
            nameText.text = character2Name;
        }

        isCharacter1Turn = !isCharacter1Turn;  // Alterna a vez do personagem
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
    }
}
