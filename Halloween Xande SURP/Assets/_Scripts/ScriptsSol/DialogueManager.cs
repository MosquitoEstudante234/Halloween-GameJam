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

    public Queue<string> sentences;
    public Queue<string> characterNames;  // Nova fila para armazenar os nomes dos personagens

    void Start()
    {
        sentences = new Queue<string>();
        characterNames = new Queue<string>(); // Inicializa a fila de nomes
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);

        // Limpa as filas de frases e personagens
        sentences.Clear();
        characterNames.Clear();

        // Adiciona as frases e os nomes dos personagens nas filas
        for (int i = 0; i < dialogue.sentences.Length; i++)
        {
            sentences.Enqueue(dialogue.sentences[i]);
            characterNames.Enqueue(dialogue.characterNames[i]);  // Adiciona os nomes alternados
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
        string characterName = characterNames.Dequeue();  // Obtém o nome do personagem para essa fala

        nameText.text = characterName;  // Atualiza o nome do personagem
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
