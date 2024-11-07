using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableStone : MonoBehaviour
{
    public Color blinkColor = Color.red; 
    public Color originalColor = Color.white; 
    public float blinkDuration = 0.5f; 
    public int maxHealth = 3; 
    private int currentHealth;

    private SpriteRenderer spriteRenderer;
    public GameObject explosionEffect; 

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = originalColor; 
        currentHealth = maxHealth;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            TakeDamage();
        }if (collision.CompareTag("Sword"))
        {
            TakeDamage();
        }
    }

    void TakeDamage()
    {
        currentHealth--;

        if (currentHealth <= 0)
        {
            Explode();
        }
        else
        {
            StartCoroutine(Blink());
        }
    }

    private IEnumerator Blink()
    {
        float elapsedTime = 0f;
        while (elapsedTime < blinkDuration)
        {
            spriteRenderer.color = Color.Lerp(originalColor, blinkColor, elapsedTime / blinkDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        spriteRenderer.color = originalColor;
    }

    private void Explode()
    {
        Destroy(gameObject);
    }
}
