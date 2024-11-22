using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeSplit : MonoBehaviour
{
    public enemyControll enemy;
    public GameObject miniSlimePrefab;
    public bool isSlime;

    private void Awake()
    {
        isSlime = true;
    }
    public void RandomGenerator()
    {
        int RandomValue = Random.Range(0, 2);
        print(RandomValue);

        switch (RandomValue)
        {
            case 0:
                break;
            case 1:
                Instantiate(miniSlimePrefab, gameObject.transform.position, Quaternion.identity);
                Instantiate(miniSlimePrefab, gameObject.transform.position, Quaternion.identity);
                break;
        }
        Destroy(gameObject);
    }
}
