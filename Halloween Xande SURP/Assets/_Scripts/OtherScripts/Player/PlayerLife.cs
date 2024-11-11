using UnityEngine;
using UnityEngine.UI;
using TMPro;
using EZCameraShake;
using System;
using System.Collections;
using UnityEngine.Events;

public class PlayerLife : MonoBehaviour
{
    public static PlayerLife Instance;

    public AudioSource damage, heal, die, coin;

    public ParticleSystem healParticle;

    public bool invunerable;

    public GameObject gameOverPanel;

    public static event Action OnPlayerDamaged;

    [SerializeField] Material normal, hit;

    [SerializeField] SpriteRenderer spriteRenderer, weapon;

    public Transform weapons;

    public UnityEvent StartWeapon;
    public UnityEvent upgradeWeapon;

    public int health;
    public int maxHealth;
    public float lerpSpeed = 0.5f;

    private void Awake()
    {
        Time.timeScale = 1f;
        Instance = this;
    }

    private void Start()
    {
        StartWeapon.Invoke();
    }

    public void TakeDamage(int dano)
    {
        if(!invunerable)
        {
            CameraShaker.Instance.ShakeOnce(10f, 10f, .3f, .3f);
            health -= dano;
            damage.Play();
            StartCoroutine(Flash());
            StartCoroutine(SetInvunerable());
            OnPlayerDamaged?.Invoke();
            if (health <= 0)
            {
                health = 0;
                gameOverPanel.SetActive(true);
                die.Play();
                SetPause();
            }
        }
    }

    public void Heal()
    {
        health = maxHealth;
        heal.Play();
        OnPlayerDamaged?.Invoke();
        StartCoroutine(Flash());
        ParticleSystem explosão = Instantiate(this.healParticle, new Vector3(transform.position.x, transform.position.y, -1), Quaternion.identity);
        Destroy(explosão.gameObject, 1f);
    }

    IEnumerator Flash()
    {
        invunerable = true;
        spriteRenderer.material = hit;
        yield return new WaitForSecondsRealtime(0.2f);
        spriteRenderer.material = normal;
        invunerable = false;
    }

    IEnumerator SetInvunerable()
    {
        invunerable = true;
        yield return new WaitForSecondsRealtime(0.5f);
        invunerable = false;
    }

    public void SetPause()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        else
            Time.timeScale = 0;
    }

    public void InvokeEvent()
    {
        upgradeWeapon.Invoke();
        coin.Play();
    }
}
