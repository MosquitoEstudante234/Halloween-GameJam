using System.Collections;
using UnityEngine;

public class MusicTransition : MonoBehaviour
{
    public AudioSource mainMusic;    // Música principal
    public AudioSource secondaryMusic; // Música secundária
    public float transitionSpeed = 0.05f; // Velocidade da transição

    private bool isTransitioning = false;

    void Start()
    {
        // Certifica-se de que as músicas estejam configuradas corretamente
        if (mainMusic != null)
        {
            mainMusic.Play();
        }

        if (secondaryMusic != null)
        {
            secondaryMusic.Play();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isTransitioning)
        {
            StartCoroutine(SwitchMusic(mainMusic, secondaryMusic));
            Debug.Log("Iniciando transição para música secundária.");
        }
    }

   /* void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isTransitioning)
        {
            StartCoroutine(SwitchMusic(secondaryMusic, mainMusic));
            Debug.Log("Voltando para a música principal.");
        }
    } */

    IEnumerator SwitchMusic(AudioSource fromMusic, AudioSource toMusic)
    {
        isTransitioning = true;

        // Ajusta o volume das músicas gradualmente
        while (fromMusic.volume > 0 || toMusic.volume < 0.1f)
        {
            fromMusic.volume = Mathf.Max(0, fromMusic.volume - Time.deltaTime * transitionSpeed);
            toMusic.volume = Mathf.Min(1, toMusic.volume + Time.deltaTime * transitionSpeed);
            yield return null; // Aguarda o próximo frame
        }

        isTransitioning = false;
    }
}
