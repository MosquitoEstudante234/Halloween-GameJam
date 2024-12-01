using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerControler : MonoBehaviour
{
    public float playerLife = 3f;
    public float damage = 1f;
    public float moveSpeed;

    public GameObject damagePanel;
    public GameObject deathPanel;
    public GameObject heart1, heart2, heart3;

    public UnityEvent OnDamage;

    Vector2 playerMovement;
    Animator playerAnimator;
    Rigidbody2D rb;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        playerMovement.x = Input.GetAxisRaw("Horizontal");
        playerMovement.y = Input.GetAxisRaw("Vertical");

        playerAnimator.SetFloat("FloatX", playerMovement.x);
        playerAnimator.SetFloat("FloatY", playerMovement.y);

        if (playerMovement.x != 0 || playerMovement.y != 0)
        {
            playerAnimator.SetFloat("speed", playerMovement.sqrMagnitude);
        }
        else
        {
            playerAnimator.SetBool("Walking", false);
        }

        switch(playerLife)
        {
            case 0: heart1.SetActive(false); heart2.SetActive(false); heart3.SetActive(false);
                break;
            case 1: heart1.SetActive(true); heart2.SetActive(false); heart3.SetActive(false);
                break;
            case 2: heart1.SetActive(true); heart2.SetActive(true); heart3.SetActive(false);
                break;
            case 3: heart1.SetActive(true); heart2.SetActive(true); heart3.SetActive(true);
                break;
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + playerMovement.normalized * moveSpeed * Time.fixedDeltaTime);
    }
    public void DamagePlayer()
    {
        playerLife -= damage;
        FindObjectOfType<AudioManager>().Play("HitPlayer");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            damagePanel.SetActive(true);
            OnDamage.Invoke();
            if (playerLife <= 0)
            {
                deathPanel.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
}