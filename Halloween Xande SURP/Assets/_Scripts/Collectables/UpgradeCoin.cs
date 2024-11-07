using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeCoin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerLife.Instance.InvokeEvent();
            Destroy(gameObject);
        }
    }
}
