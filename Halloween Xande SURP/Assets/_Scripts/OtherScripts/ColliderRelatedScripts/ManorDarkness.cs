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
    private float transitionTimer = 0f; // Temporizador para verificar o tempo da transição
    private bool isPlayerInTrigger = false; // Verifica se o player está no trigger

    void Start()
    {
        // Inicia uma checagem repetitiva a cada 10 segundos
        InvokeRepeating(nameof(CheckTransitionStatus), 10f, 10f);
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("HauntedHouse"))
        {
            isPlayerInTrigger = true;

            if (!isTransitioning)
            {
                StartCoroutine(TransitionEffects(mainEffect, hauntedEffect, false));
                Debug.Log("Entrou no trigger");
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("HauntedHouse"))
        {
            isPlayerInTrigger = false;

            if (!isTransitioning)
            {
                StartCoroutine(TransitionEffects(hauntedEffect, mainEffect, true));
                Debug.Log("Saiu do trigger");
            }
        }
    }

    IEnumerator TransitionEffects(PostProcessVolume fromEffect, PostProcessVolume toEffect, bool reset)
    {
        isTransitioning = true;
        transitionTimer = 0f; // Reseta o temporizador quando a transição começa

        while (fromEffect.weight > 0 || toEffect.weight < 1)
        {
            // Incrementa o temporizador
            transitionTimer += Time.deltaTime;

            // Transição gradual entre os efeitos
            fromEffect.weight = Mathf.Max(0, fromEffect.weight - Time.deltaTime * transitionSpeed);
            toEffect.weight = Mathf.Min(1, toEffect.weight + Time.deltaTime * transitionSpeed);

            // Aguarda um frame antes de continuar
            yield return null;
        }

        // Se for uma transição de saída, reseta o efeito principal para o peso máximo
        if (reset)
        {
            mainEffect.weight = 1;
            hauntedEffect.weight = 0;
        }

        isTransitioning = false;
        transitionTimer = 0f; // Reseta o temporizador quando a transição termina
    }

    void CheckTransitionStatus()
    {
        if (isTransitioning)
        {
            Debug.Log("O player ainda está em transição.");

            // Verifica se a transição está durando mais de 5 segundos
            if (transitionTimer > 5f)
            {
                Debug.LogWarning("A transição está durando muito tempo! Cancelando...");
                StopAllCoroutines(); // Cancela todas as corrotinas (parando a transição)

                if (!isPlayerInTrigger)
                {
                    // Aplica o efeito principal se o player não estiver no trigger
                    Debug.Log("Player não está no trigger. Aplicando o efeito principal.");
                    mainEffect.weight = 1;
                    hauntedEffect.weight = 0;
                }

                ResetEffects(); // Reseta os estados de controle
            }
        }
        else
        {
            Debug.Log("O player não está em transição.");
        }
    }

    void ResetEffects()
    {
        // Reseta os estados de controle
        isTransitioning = false;
        transitionTimer = 0f;
    }
}
