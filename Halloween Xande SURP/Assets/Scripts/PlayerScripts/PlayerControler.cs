using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerControler : MonoBehaviour
{
    public float playerLife = 3f;
    public float damage = 1f;
    public float moveSpeed;
    public GameObject deathPanel;
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
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + playerMovement.normalized * moveSpeed * Time.fixedDeltaTime);
    }
    void DamagePlayer()
    {
        playerLife -= damage;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            DamagePlayer();
            if (playerLife <= 0)
            {
                deathPanel.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
}