using EZCameraShake;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BossSpinLife : MonoBehaviour
{
    public AudioSource source;
    public int maxVidas;
    public int vidas;
    public ParticleSystem particula;
    [SerializeField] SpriteRenderer spriteRenderer;
    public Slider barraDeVida;

    public GameObject upgradeCoinPrefab;
    public GameObject coinPrefab;

    [SerializeField] Material normal, hit;
    [SerializeField] Animator animator;

    private void Start()
    {
        vidas = maxVidas;
        barraDeVida.maxValue = maxVidas;
        UpdateLifeBar();

    }
    public void TakeDamage(int damage)
    {
        source.Play();
        vidas -= damage;
        UpdateLifeBar();
        StartCoroutine(FlashHit());
        if (vidas <= 0)
        {
            int randomCoins = Random.Range(5, 10);
            for (int i = 0; i < randomCoins; i++)
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
        spriteRenderer.material = hit;
        yield return new WaitForSecondsRealtime(0.2f);
        spriteRenderer.material = normal;
        animator.SetTrigger("Dano");
        
    }
    void UpdateLifeBar()
    {
        barraDeVida.value = vidas;
    }
}
