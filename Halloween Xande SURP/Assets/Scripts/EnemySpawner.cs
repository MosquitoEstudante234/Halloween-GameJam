using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject BatEnemyPrefab;
    public GameObject BatEnemyFastPrefab;
    public GameObject BatEnemySlowPrefab;
    public GameObject GhostEnemyPrefab;
    public GameObject SlimeEnemyPrefab;

    public float SpawnSeconds;
    public void RandomGenerator()
    {
        int RandomValue = Random.Range(0, 5);
        print(RandomValue);

        switch (RandomValue)
        {
            case 0:
                Instantiate(BatEnemyPrefab, gameObject.transform.position, Quaternion.identity);
                break;
            case 1:
                Instantiate(BatEnemyFastPrefab, gameObject.transform.position, Quaternion.identity);
                break;
            case 2:
                Instantiate(BatEnemySlowPrefab, gameObject.transform.position, Quaternion.identity);
                break;
            case 3:
                Instantiate(GhostEnemyPrefab, gameObject.transform.position, Quaternion.identity);
                break;
            case 4:
                Instantiate(SlimeEnemyPrefab, gameObject.transform.position, Quaternion.identity);
                break;
        }
    }
    private void Start()
    {
        StartCoroutine(SpawnTime());
    }

    public IEnumerator SpawnTime()
    {
        yield return new WaitForSeconds(SpawnSeconds);
        RandomGenerator();
        StartCoroutine(SpawnTime());
    }
}

