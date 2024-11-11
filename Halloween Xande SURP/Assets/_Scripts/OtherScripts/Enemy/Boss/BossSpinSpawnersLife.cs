using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpinSpawnersLife : MonoBehaviour
{
    public int maxVidas;
    public int vidas;
    [SerializeField] ParticleSystem particula;
    SpriteRenderer spriteRenderer;

    [SerializeField] Material normal, hit;
    public AudioSource source;
    BossSpinState state;
    BossSpinLife bossLife;
    public bool rotateAfterDie;
    [SerializeField] int damageAfterDie;
    [SerializeField] Animator animator;

    private void Start()
    {
        state = gameObject.GetComponentInParent<BossSpinState>();
        bossLife = gameObject.GetComponentInParent<BossSpinLife>();
        vidas = maxVidas;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            bullet bulLet = collision.gameObject.GetComponent<bullet>();
            if (bulLet != null)
            {
                TakeDamage(1);
            }
            else
            {
                TakeDamage(2);
            }
        }

        if (collision.CompareTag("Sword"))
        {
            TakeDamage(1);
        }
    }

    public void TakeDamage(int damage)
    {
        vidas -= damage;
        StartCoroutine(FlashHit());
        if (vidas <= 0)
        {
            if (rotateAfterDie)
            {
                state.SwitchDirection();
            }
            bossLife.TakeDamage(damageAfterDie);
            ParticleSystem explosão = Instantiate(this.particula, new Vector3(transform.position.x, transform.position.y, -1), Quaternion.identity);
            Destroy(explosão.gameObject, 1f);
            Destroy(gameObject);
        }
    }

    public IEnumerator FlashHit()
    {
        spriteRenderer.material = hit;
        yield return new WaitForSecondsRealtime(0.2f);
        spriteRenderer.material = normal;
    }
}
