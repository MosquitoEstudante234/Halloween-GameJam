using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;
using UnityEngine.AI;
using UnityEngine.UI;

public class BossLife : MonoBehaviour
{
    public AudioSource source;
    public int maxVidas;
    public int vidas;
    NavMeshAgent agent;
    public ParticleSystem particula;
    [SerializeField] SpriteRenderer spriteRenderer;
    public Slider barraDeVida;
    public GameObject linha2;
    int metadeDaVida;

    public float maxSpeed;
    public bool isInvencible;

    public GameObject upgradeCoinPrefab;
    public GameObject coinPrefab;

    [SerializeField] Material normal, hit;
    // Start is called before the first frame update
    void Start()
    {
        vidas = maxVidas;
        metadeDaVida = maxVidas / 2;
        barraDeVida.maxValue = maxVidas;
        agent = GetComponent<NavMeshAgent>();
        UpdateLifeBar();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            CameraShaker.Instance.ShakeOnce(1f, 1f, 0.2f, 0.2f);
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

    public void TakeDamage(int damage)
    {
        if (isInvencible)
        {
            return;
        }
        source.Play();
        vidas -= damage;
        if(vidas <= metadeDaVida)
        {
            linha2.SetActive(true);
        }
        UpdateLifeBar();
        StartCoroutine(FlashHit());
        if (vidas <= 0)
        {
            int randomCoins = Random.Range(5, 10);
            for(int i = 0; i < randomCoins; i++)
            {
                Instantiate(coinPrefab, transform.position, transform.rotation);
            }
            Instantiate(upgradeCoinPrefab, transform.position, transform.rotation);
            source.Play();
            ParticleSystem explosão = Instantiate(this.particula, new Vector3(transform.position.x, transform.position.y, -1), Quaternion.identity);
            Destroy(explosão.gameObject, 1f);
            Destroy(gameObject);
        }
    }

    public IEnumerator FlashHit()
    {
        agent.speed = 0;
        spriteRenderer.material = hit;
        yield return new WaitForSecondsRealtime(0.2f);
        agent.speed = maxSpeed;
        spriteRenderer.material = normal;
    }

    void UpdateLifeBar()
    {
        barraDeVida.value = vidas;
    }
}
