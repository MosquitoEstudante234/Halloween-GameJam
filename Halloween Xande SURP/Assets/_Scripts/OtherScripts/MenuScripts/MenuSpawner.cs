using UnityEngine;

public class MenuSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public Transform spawnPoint;
    public Transform canvasTransform;

    private float timeToNextSpawn;
    private float timer;

    void Start()
    {
        SetRandomTime();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeToNextSpawn)
        {
            SpawnObject();

            timer = 0f;

            SetRandomTime();
        }
    }

    void SetRandomTime()
    {
        timeToNextSpawn = Random.Range(5f, 10f);
    }

    void SpawnObject()
    {
        GameObject newObject = Instantiate(objectToSpawn, spawnPoint.position, Quaternion.identity);

        newObject.transform.SetParent(canvasTransform, false);
    }
}
