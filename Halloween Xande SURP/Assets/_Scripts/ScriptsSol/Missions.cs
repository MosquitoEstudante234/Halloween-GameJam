using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Missions : MonoBehaviour
{
    public static Missions Instance;

    public TMP_Text m_Text;

    public GameObject teleport, Boss, Boss2, Boss3;
    public Transform location, loc2, loc3;

    List<enemyControll> Enemies = new List<enemyControll>();
    int enemiesKilled;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Enemies.AddRange(FindObjectsOfType<enemyControll>(true));
        m_Text.text = $"{enemiesKilled}/{Enemies.Count - 2}";
        Instantiate(Boss, location.position, Quaternion.identity);
        Instantiate(Boss2, loc2.position, Quaternion.identity);
        Instantiate(Boss3, loc3.position, Quaternion.identity);
    }

    public void UpdateText() 
    {
        enemiesKilled++;
        if(enemiesKilled >= Enemies.Count - 2) 
        {
            m_Text.text = "Va para a Casa Assombrada";
            teleport.SetActive(true);
            return;
        }
        m_Text.text = $"{enemiesKilled}/{Enemies.Count - 2}";

    }
}
