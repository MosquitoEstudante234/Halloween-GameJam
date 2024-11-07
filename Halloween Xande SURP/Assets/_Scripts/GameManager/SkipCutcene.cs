using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SkipCutcene : MonoBehaviour
{
    public string sceneName;
    public Image enterImage; 
    public float fadeDuration = 1f; 
    private bool isImageVisible = false;

    void Start()
    {
        enterImage.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace)) 
        {
            if (!isImageVisible)
            {
                StartCoroutine(FadeIn());
            }
            else
            {
                SceneManager.LoadScene(sceneName);
            }
        }
    }

    private IEnumerator FadeIn()
    {
        enterImage.gameObject.SetActive(true);
        Color color = enterImage.color;
        color.a = 0; 
        enterImage.color = color;

        // Faz o fade in
        while (color.a < 1)
        {
            color.a += Time.deltaTime / fadeDuration; 
            enterImage.color = color;
            yield return null;
        }

        isImageVisible = true; 
    }
}
