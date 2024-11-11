using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string[] characterNames;  // Agora temos dois ou mais personagens, então um array para os nomes
    [TextArea(3, 10)]
    public string[] sentences;  // Falas dos personagens
}
