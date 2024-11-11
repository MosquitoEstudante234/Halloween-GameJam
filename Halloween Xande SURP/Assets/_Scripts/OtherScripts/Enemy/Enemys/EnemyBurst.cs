using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class EnemyBurst : MonoBehaviour
{
    public AudioSource source;
    public int vidas;
    public ParticleSystem particula;
    [SerializeField] SpriteRenderer spriteRenderer;

    [SerializeField] Material normal, hit;

    public GameObject coinPrefab;

    public GameObject projectile;
    public Transform playerPos, firePos;
    public float cooldown;
    public int burstCount;
    public float timeBeetweenBurst;

    void Start()
    {
        StartCoroutine(ShootPlayer());
        cooldown = Random.Range(1, 4);
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

    public IEnumerator ShootPlayer()
    {
        cooldown = Random.Range(0, 5);
        yield return new WaitForSeconds(cooldown);
        for(int i = 0; i < burstCount; i++)
        {
            Instantiate(projectile, firePos.position, firePos.rotation);
            yield return new WaitForSeconds(timeBeetweenBurst);
        }
        StartCoroutine(ShootPlayer());
    }

    public IEnumerator FlashHit()
    {
        spriteRenderer.material = hit;
        yield return new WaitForSecondsRealtime(0.2f);
        spriteRenderer.material = normal;
    }
}
