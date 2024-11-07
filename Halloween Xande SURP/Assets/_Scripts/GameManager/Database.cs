using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Weapon
{
    public string name;
    public Sprite sprite;
    public GameObject prefab;
}
public class Database : MonoBehaviour
{
    public static Database Instance;
    public Weapon[] weapons;
    void Start()
    {
        Instance = this;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
