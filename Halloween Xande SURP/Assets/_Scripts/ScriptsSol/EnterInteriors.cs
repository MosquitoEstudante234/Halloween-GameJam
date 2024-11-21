using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

public class EnterInteriors : MonoBehaviour
{
    public PostProcessVolume mainEffect;       // Efeito principal
    public PostProcessVolume teleportEffect;   // Efeito de transição
    public float transitionSpeed = 1f;         // Velocidade da transição
    public Transform targetPoint;              // Destino para onde teletransportar
    public Transform npcFriend;                // NPC que será teletransportado com o player
    public Collider2D targetCollider;          // Colisor do ponto de destino
    public float disableDuration = 5f;         // Tempo para desativar o ponto de destino

    public bool isTransitioning = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica se o player entrou no colisor
        if (other.CompareTag("Player") && !isTransitioning)
        {
            // Desativa temporariamente o colisor do ponto de destino
            StartCoroutine(ReenableTargetCollider());

            // Inicia a transição e teletransporta o player e o NPC
            StartCoroutine(TransitionAndTeleport(other.transform));
            print(other);
            targetCollider.enabled = false;
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

        // Teletransporta o player e o NPC para o ponto de destino
        player.position = targetPoint.position;
        npcFriend.GetComponent<NavMeshAgent>().enabled = false;
        npcFriend.position = player.position;

        // Reverte a transição para restaurar o efeito principal
        while (mainEffect.weight < 1 || teleportEffect.weight > 0)
        {
            mainEffect.weight = Mathf.Min(1, mainEffect.weight + Time.deltaTime * transitionSpeed);
            teleportEffect.weight = Mathf.Max(0, teleportEffect.weight - Time.deltaTime * transitionSpeed);
            npcFriend.GetComponent<NavMeshAgent>().enabled = true;
            isTransitioning = false;

            yield return null;
        }
    }

    private IEnumerator ReenableTargetCollider()
    {
        // Espera pelo tempo de desativação
        yield return new WaitForSeconds(disableDuration);

        // Reativa o colisor do ponto de destino
        targetCollider.enabled = true;
    }
}
