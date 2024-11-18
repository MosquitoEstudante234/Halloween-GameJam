using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cure : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.GetComponent<PlayerControler>().playerLife < 3)
            {
                collision.gameObject.GetComponent<PlayerControler>().playerLife++;
            }
            Destroy(gameObject);
        }
    }
}
