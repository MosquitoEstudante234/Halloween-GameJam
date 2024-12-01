using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerSurvive : MonoBehaviour
{
    public float levelTimer;
    public TMP_Text timerText;
    private void Update()
    {
        levelTimer -= Time.deltaTime;
        timerText.text = levelTimer.ToString("F0");
        if (levelTimer <= 0)
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
