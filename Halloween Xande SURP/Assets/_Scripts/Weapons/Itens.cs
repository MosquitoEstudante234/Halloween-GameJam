using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class Itens : MonoBehaviour
{
    public static Itens Instance;
    public TextMeshProUGUI text;
    public GameObject choice1;

    void Start()
    {
        GameObject facas = GameObject.FindGameObjectWithTag("Facas");
        GameObject sword = GameObject.FindGameObjectWithTag("Scimitarra");

        EventSystem.current.SetSelectedGameObject(choice1);

        if (facas == null && sword != null)
        {
            text.text = "Aumentar Dano";
        }
        else if (sword == null && facas != null)
        {
            text.text = "Aumentar numero de balas";
        }
        else
        {
            text.text = "??";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseLife(int lifeIncrease)
    {
        PlayerLife.Instance.maxHealth += lifeIncrease;
        PlayerLife.Instance.Heal();
    }

    public void IncreaseSpeed(int speedIncrease)
    {
        PlayerMove.Instance.speed += speedIncrease;
    }

    public void IncreaseDashSpeed(int dashSpeedIncrease)
    {
        PlayerMove.Instance.rollSpeed += dashSpeedIncrease;
    }

    public void IncreaseBalas(int damageIncrease)
    {
        GameObject facas = GameObject.FindGameObjectWithTag("Facas");
        GameObject sword = GameObject.FindGameObjectWithTag("Scimitarra");

        if (facas == null && sword != null)
        {
            Scmitar.Instance.damage += damageIncrease;
            print(Scmitar.Instance.damage);
        }
        else if(sword == null && facas != null)
        {
            ShootAndAim.Instance.maxAmmo += damageIncrease;
        }
        else
        {
            return;
        }
    }

    public void IncreaseCuras(int increase)
    {
        HealFlasks.instance.maxFlasks += increase;
        HealFlasks.instance.currentFlasks = HealFlasks.instance.maxFlasks;
        HealFlasks.instance.UpdateSlider();
    }
}
