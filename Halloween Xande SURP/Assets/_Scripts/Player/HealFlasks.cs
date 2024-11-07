using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealFlasks : MonoBehaviour
{
    public static HealFlasks instance;

    public int maxFlasks = 6;
    public int currentFlasks;
    public float flaskCooldown = 60f; // 60 segundos
    private float flaskTimer;

    public Slider cooldownSlider;
    public TextMeshProUGUI flaskCount;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        currentFlasks = 2;
        flaskTimer = 0;
        UpdateSlider();
    }

    void Update()
    {

        // Uso do frasco ao pressionar Tab
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            UseFlask();
        }
    }

    void UseFlask()
    {
        if (currentFlasks > 0)
        {
            currentFlasks--;
            PlayerLife.Instance.Heal();
            UpdateSlider();
        }
    }

    public void Gain(float amount)
    {
        // Regenerar um frasco a cada 60 segundos
        if (currentFlasks < maxFlasks)
        {
            flaskTimer += amount;
            UpdateSlider();

            if (flaskTimer >= flaskCooldown)
            {
                currentFlasks++;
                flaskTimer = 0;
                UpdateSlider();
            }
        }
        if (currentFlasks >= maxFlasks)
        {
            currentFlasks = maxFlasks;
            UpdateSlider();
        }
    }

    public void UpdateSlider()
    {
        flaskCount.text = currentFlasks.ToString();

        if (currentFlasks <= maxFlasks)
        {
            cooldownSlider.value = flaskTimer / flaskCooldown;
        }
        else
        {
            cooldownSlider.value = 1;
        }
    }
}
