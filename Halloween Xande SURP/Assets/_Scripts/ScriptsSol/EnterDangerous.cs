using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

public class EnterDangerous : MonoBehaviour
{
    public PostProcessVolume mainEffect;       // Efeito principal
    public PostProcessVolume teleportEffect;   // Efeito de transição
    public float transitionSpeed = 1f;         // Velocidade da transição
    public Transform targetPoint;              // Destino para onde teletransportar
    public Transform npcFriend;                // NPC que será teletransportado com o player
    public Collider2D targetCollider;          // Colisor do ponto de destino
    public Collider2D initialCollider;         // Colisor do ponto de destino
    public int remainingEnemies;           // Número de inimigos restantes
    public enemyControll[] enemiesInHouse;



    private bool isTransitioning = false;

    private void Awake()
    {
        remainingEnemies = enemiesInHouse.Length;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica se o player entrou no colisor
        if (other.CompareTag("Player") && !isTransitioning)
        {
            // Desativa o colisor do ponto de destino
            if (targetCollider != null)
            {
                targetCollider.enabled = false;
            }
            targetCollider.enabled = false;


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

            yield return null;
        }

        isTransitioning = false;

        // Inicia a checagem dos inimigos restantes para reativar o colisor
        StartCoroutine(CheckEnemiesAndReenableCollider());
    }

    private IEnumerator CheckEnemiesAndReenableCollider()
    {
        // Espera até que a quantidade de inimigos restantes seja zero
        while (remainingEnemies > 0)
        {
            yield return null; // Espera um frame antes de verificar novamente
        }

        if (targetCollider != null)
        {
            yield return new WaitForSeconds(3);
            targetCollider.enabled = true;
        }
    }
}
