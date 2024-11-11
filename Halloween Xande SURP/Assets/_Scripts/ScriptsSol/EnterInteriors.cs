using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

public class EnterInteriors : MonoBehaviour
{
    public PostProcessVolume mainEffect;     // Efeito principal
    public PostProcessVolume teleportEffect; // Efeito de teletransporte
    public float transitionSpeed = 1f;       // Velocidade da transição
    public Transform destination;            // Ponto de teletransporte
    public Transform npcFriend;              // NPC que será teletransportado com o player

    private bool isTransitioning = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica se o player entrou no colisor
        if (other.CompareTag("Player") && !isTransitioning)
        {
            // Inicia a transição e teletransporta o player e o NPC
            StartCoroutine(TransitionAndTeleport(other.transform));
        }
    }

    private IEnumerator TransitionAndTeleport(Transform player)
    {
        isTransitioning = true;

        // Ativa a transição do efeito principal para o efeito de teletransporte
        while (mainEffect.weight > 0 || teleportEffect.weight < 1)
        {
            mainEffect.weight = Mathf.Max(0, mainEffect.weight - Time.deltaTime * transitionSpeed);
            teleportEffect.weight = Mathf.Min(1, teleportEffect.weight + Time.deltaTime * transitionSpeed);

            yield return null; // Espera um frame antes de continuar
        }

        // Após a transição, teletransporta o player e o NPC
        player.position = destination.position;
        if (npcFriend != null)
            npcFriend.position = destination.position;

        // Reverte a transição para restaurar o efeito principal
        while (mainEffect.weight < 1 || teleportEffect.weight > 0)
        {
            mainEffect.weight = Mathf.Min(1, mainEffect.weight + Time.deltaTime * transitionSpeed);
            teleportEffect.weight = Mathf.Max(0, teleportEffect.weight - Time.deltaTime * transitionSpeed);

            yield return null;
        }

        isTransitioning = false;
    }
}
