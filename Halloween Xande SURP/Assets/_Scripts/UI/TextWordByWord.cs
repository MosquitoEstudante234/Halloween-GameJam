using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextWordByWord : MonoBehaviour
{
    public TextMeshProUGUI textDisplay; // Arraste seu componente TextMeshProUGUI aqui
    public string fullText; // O texto completo que será exibido
    public float typingSpeed = 0.05f; // Velocidade de digitação (tempo entre cada letra)

    private string currentText = "";

    void Start()
    {
        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        for (int i = 0; i < fullText.Length; i++)
        {
            currentText += fullText[i];
            textDisplay.text = currentText;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
