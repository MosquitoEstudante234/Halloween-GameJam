using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

public class ManorDarkness : MonoBehaviour
{
    public PostProcessVolume mainEffect;    // Volume do efeito atual
    public PostProcessVolume hauntedEffect; // Volume do segundo efeito (ex. casa assombrada)
    public float transitionSpeed = 1f; // Velocidade de transição

    private bool isTransitioning = false;

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("HauntedHouse") && !isTransitioning)
        {
            StartCoroutine(TransitionEffects(mainEffect, hauntedEffect, false));
            Debug.Log("Entrou no trigger");
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("HauntedHouse") && !isTransitioning)
        {
            StartCoroutine(TransitionEffects(hauntedEffect, mainEffect, true));
            Debug.Log("Saiu do trigger");
        }
    }

    IEnumerator TransitionEffects(PostProcessVolume fromEffect, PostProcessVolume toEffect, bool reset)
    {
        isTransitioning = true;

        while (fromEffect.weight > 0 || toEffect.weight < 1)
        {
            // Transição gradual entre os efeitos
            fromEffect.weight = Mathf.Max(0, fromEffect.weight - Time.deltaTime * transitionSpeed);
            toEffect.weight = Mathf.Min(1, toEffect.weight + Time.deltaTime * transitionSpeed);

            yield return null; // Espera um frame antes de continuar
        }

        // Se for uma transição de saída, reseta o efeito principal para o peso máximo
        if (reset)
        {
            mainEffect.weight = 1;
            hauntedEffect.weight = 0;
        }

        isTransitioning = false;
    }
}
