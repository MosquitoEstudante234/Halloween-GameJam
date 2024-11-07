using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public bool inReach = false;
    public string nextScene;
    public GameObject persistencePrefab;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (nextScene == "Menu")
            {
                Persistence.Instance.destroy = true;
                SceneManager.LoadScene(nextScene);
            }
            else
            {
                SceneManager.LoadScene(nextScene);
                PlayerLife.Instance.transform.position = new Vector3(-3f, 0, 0);
                Camera.main.transform.position = new Vector3(-3f, 0, 0);
            }
        }
    }
}
