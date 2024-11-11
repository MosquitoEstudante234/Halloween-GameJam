using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string character1Name;  // Nome do primeiro personagem
    public string character2Name;  // Nome do segundo personagem

    [TextArea(3, 10)]
    public string[] sentences;  // Falas que serão alternadas entre os personagens
}
