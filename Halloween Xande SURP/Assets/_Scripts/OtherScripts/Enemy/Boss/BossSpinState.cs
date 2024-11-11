using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpinState : MonoBehaviour
{
    public float rotationSpeed = 100f;
    private int direction = 1;
    public GameObject[] straightSpawners;
    public GameObject straightSpawnersParent;
    public GameObject rotateSpawnersParent;

    void FixedUpdate()
    {
        straightSpawners = GameObject.FindGameObjectsWithTag("NPC");

        transform.Rotate(0, 0, direction * rotationSpeed * Time.deltaTime);

        if(straightSpawners.Length == 0)
        {
            straightSpawnersParent.SetActive(false);
            rotateSpawnersParent.SetActive(true);
        }
    }

    public void SwitchDirection()
    {
        direction *= -1;
    }
}
