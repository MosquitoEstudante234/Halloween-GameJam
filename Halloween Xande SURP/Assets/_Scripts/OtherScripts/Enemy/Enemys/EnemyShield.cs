using EZCameraShake;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShield : MonoBehaviour
{
    public AudioSource source;
    public int vidas;
    public ParticleSystem particula;
    [SerializeField] SpriteRenderer spriteRenderer;

    [SerializeField] Material normal, hit;

    public GameObject coinPrefab;
    void Start()
    {
    }

    public void TakeDamage(int damage)
    {
        vidas -= damage;
        source.Play();
        StartCoroutine(FlashHit());
        if (vidas <= 0)
        {
            source.Play();
            int randomNumber = Random.Range(1, 100);
            if (randomNumber <= 50)
            {
                Instantiate(coinPrefab, new Vector3(transform.position.x, transform.position.y, -1), Quaternion.identity);
            }
            ParticleSystem explosão = Instantiate(this.particula, new Vector3(transform.position.x, transform.position.y, -1), Quaternion.identity);
            Destroy(explosão.gameObject, 1f);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            CameraShaker.Instance.ShakeOnce(2f, 2f, 0.2f, 0.2f);
            bullet bulLet = collision.gameObject.GetComponent<bullet>();
            if (bulLet != null)
            {
                TakeDamage(bullet.Instance.dano);
            }
            else
            {
                TakeDamage(2);
            }
        }

        if (collision.CompareTag("Sword"))
        {
            CameraShaker.Instance.ShakeOnce(1f, 1f, 0.2f, 0.2f);
            TakeDamage(Scmitar.Instance.damage);
        }
    }

    public IEnumerator FlashHit()
    {
        spriteRenderer.material = hit;
        yield return new WaitForSecondsRealtime(0.2f);
        spriteRenderer.material = normal;
    }
}
