using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Missions : MonoBehaviour
{
    public static Missions Instance;

    public TMP_Text m_Text;

    public GameObject teleport;

    List<enemyControll> Enemies = new List<enemyControll>();
    int enemiesKilled;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Enemies.AddRange(FindObjectsOfType<enemyControll>(true));
        m_Text.text = enemiesKilled.ToString() + "/" + Enemies.Count.ToString();

    }

    public void UpdateText() 
    {
        enemiesKilled++;
        if(enemiesKilled > Enemies.Count - 1) 
        {
            m_Text.text = "Va para a Mansão";
            teleport.SetActive(true);
        }
        m_Text.text = enemiesKilled.ToString() + "/" + Enemies.Count.ToString();

    }
}
