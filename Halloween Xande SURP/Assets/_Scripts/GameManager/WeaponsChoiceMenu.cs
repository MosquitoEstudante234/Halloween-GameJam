using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class WeaponsChoiceMenu : MonoBehaviour
{
    public TMP_Text[] weaponName = new TMP_Text[4];
    public Image[] weaponIcons = new Image[4];
    GameObject[] choicedWeapon = new GameObject[4];
    Sprite[] choicedWeaponImage = new Sprite[4];
    public UnityEvent OnLuck;
    public static int luck;
    void Start()
    {
        List<Weapon>weapons = Database.Instance.weapons.ToList();
        for (int i = 0; i < weaponName.Length; i++) 
        {
            int randomNumber = Random.Range(0, weapons.Count);
            choicedWeapon[i] = weapons[randomNumber].prefab;
            choicedWeaponImage[i] = weapons[randomNumber].sprite;
            weapons.RemoveAt(randomNumber);
            weaponIcons[i].sprite = choicedWeaponImage[i];
            weaponName[i].text = choicedWeapon[i].name;
            
            if (i == 2)
            {
                if (luck == 0)
                    return;

                if (Random.Range(0, 100) < 1 - 1 / luck)
                {
                    OnLuck.Invoke();
                }
                else
                    break;

            }
        }

       
    }

    public void WeaponChoosed(int id)
    {
        if(PlayerWeapons.Instance.weapons.Count == 0)
        {
            Instantiate(choicedWeapon[id], PlayerLife.Instance.weapons);
            PlayerWeapons.Instance.weapons.Add(choicedWeapon[id]);
            return;
        }
        for(int i  = 0; i < PlayerWeapons.Instance.weapons.Count; i++)
        {
            if (PlayerWeapons.Instance.weapons[1].name.Equals(choicedWeapon[id].name))
            {
                print("coletado");
                break;
            }
            else
            {
                if (i == PlayerWeapons.Instance.weapons.Count - 1)
                {
                    Instantiate(choicedWeapon[id], PlayerLife.Instance.weapons);
                    PlayerWeapons.Instance.weapons.Add(choicedWeapon[id]);
                    break;
                }
            }
        }
    }
    //ler mais...
}
