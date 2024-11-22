using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public int BossesLeft;
    public static EndGame Instance;
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(BossesLeft <= 0)
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
