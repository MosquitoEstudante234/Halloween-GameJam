using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float lerpSpeed;
    SpriteRenderer spriteRenderer;
    Color spriteColor;
    bool hasInstantiated = false;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteColor = spriteRenderer.color;
        spriteColor.a = 0f;
        spriteRenderer.color = spriteColor;
    }

    // Update is called once per frame
    void Update()
    {
        spriteColor.a = Mathf.Lerp(spriteColor.a, 1f, lerpSpeed * Time.deltaTime);
        spriteRenderer.color = spriteColor;

        if (spriteColor.a >= 0.99f && !hasInstantiated)
        {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject); 
            hasInstantiated = true;
        }
    }
}
