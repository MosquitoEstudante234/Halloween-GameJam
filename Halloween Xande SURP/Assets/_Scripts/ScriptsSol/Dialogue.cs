using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string character1Name;  
    public string character2Name;  

    [TextArea(3, 10)]
    public string[] sentences;  
}
