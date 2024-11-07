using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public float moveSpeed;
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

        if (playerMovement.x != 0 || playerMovement.y != 0)
        {
            playerAnimator.SetBool("Walking", true);
            playerAnimator.SetFloat("FloatX", playerMovement.x);
            playerAnimator.SetFloat("FloatY", playerMovement.y);
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
}
