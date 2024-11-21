using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject BatEnemyPrefab;
    public GameObject BatEnemyFastPrefab;
    public GameObject BatEnemySlowPrefab;
    public GameObject GhostEnemyPrefab;
    public GameObject SlimeEnemyPrefab4;
    public void RandomGenerator()
    {
        int RandomValue = Random.Range(0, 4);
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
                Instantiate(SlimeEnemyPrefab4, gameObject.transform.position, Quaternion.identity);
                break;
        }
    }
    private void Start()
    {
        
        RandomGenerator();
    }
    
}

