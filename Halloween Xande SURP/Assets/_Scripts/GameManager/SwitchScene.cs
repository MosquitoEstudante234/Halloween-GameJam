using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    public string nextScene;
    private void Start()
    {
        SceneChange(nextScene);
    }
    public void SceneChange(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
