
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Wave
{
    public List<GameObject> enemies; // Lista de inimigos para essa onda
}

public class BattleTrigger : MonoBehaviour
{
    public bool isTriggered;

    [Header("Wave Settings")]
    public List<Wave> waves; // Lista de ondas

    [SerializeField] private Collider2D currentRoomSpawnableArea;
    [SerializeField] private GameObject walls;
    [SerializeField] private BoxCollider2D col;

    private int currentWave = 0; // Onda atual
    private GameObject player;
    private GameObject[] enemiesInScene;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isTriggered)
        {
            isTriggered = true;
            StartCoroutine(SpawnWave());
        }
    }

    private void FixedUpdate()
    {
        enemiesInScene = GameObject.FindGameObjectsWithTag("Enemy");
        Battle();
    }

    public void Battle()
    {
        if (isTriggered && enemiesInScene.Length == 0 && currentWave < waves.Count)
        {
            StartCoroutine(SpawnWave());
        }
        else if (isTriggered && enemiesInScene.Length == 0 && currentWave >= waves.Count)
        {
            EndBattle();
        }
    }

    private IEnumerator SpawnWave()
    {
        if (currentWave < waves.Count)
        {
            // pega a lista de inimigos pra spawnar
            walls.SetActive(true);
            List<GameObject> enemiesToSpawn = waves[currentWave].enemies;
            BattleManager.instance.SpawnEnemies(currentRoomSpawnableArea, enemiesToSpawn.ToArray()); // Convertendo para array

            currentWave++;
            yield return null;
        }
    }

    private void EndBattle()
    {
        walls.SetActive(false);
        Destroy(col);
        Destroy(gameObject);
    }
}
