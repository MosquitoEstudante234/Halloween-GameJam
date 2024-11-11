using EZCameraShake;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public enum State
{
    Normal,
    Rolling
}

public class PlayerMove : MonoBehaviour
{
    public SpriteRenderer playerSR, gunSR;

    public Transform t;

    public static PlayerMove Instance;

    private Vector2 worldPosition;
    private Vector2 direction;

    public InputAction inputAction;

    public float speed;
    public Rigidbody2D rb;
    float horizontal, vertical;
    Vector2 moveDir = Vector2.zero;
    public Vector2 move;
    public float rollSpeed;
    public float rollDuration, rollCooldown, maxCooldown;
    public GameObject walkSound;

    public bool canDash, isDashing;

    public static PlayerMove player;

    public Animator anim;

    public static State state;

    private void OnEnable()
    {
        inputAction.Enable();
    }

    private void OnDisable()
    {
        inputAction.Disable();
    }

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        rollCooldown = maxCooldown;
        canDash = true;
        state = State.Normal;
        player = this;
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        switch (state) 
        {
            case State.Normal:
                Movement();
                break;

            case State.Rolling:
                StartCoroutine(Roll());
                break;
        }

    }

    IEnumerator Roll()
    {
        canDash = false;
        moveDir = inputAction.ReadValue<Vector2>();
        rb.velocity = moveDir * rollSpeed;
        yield return new WaitForSeconds(rollDuration);
        state = State.Normal;

        yield return new WaitForSeconds(rollCooldown);
        canDash = true;
        rollCooldown = maxCooldown;
    }

    void Movement()
    {
        //horizontal = Input.GetAxisRaw("Horizontal");
        //vertical = Input.GetAxisRaw("Vertical");

        anim.SetFloat("Speed", Mathf.Abs(moveDir.x != 0 ? moveDir.x : moveDir.y));

        moveDir = inputAction.ReadValue<Vector2>();

        rb.velocity = moveDir * speed;

        if(Mathf.Abs(moveDir.x != 0 ? moveDir.x : moveDir.y) > 0)
        {
            walkSound.SetActive(true);
        }
        else 
        { 
            walkSound.SetActive(false); 
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (!canDash)
                return;
            state = State.Rolling;
        }

        if (GameManager.Instance.controller)
        {
            move = Gamepad.current.rightStick.ReadValue();
            direction = move;
        }
        else
        {
            worldPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            direction = (worldPosition - (Vector2)this.transform.position).normalized;
        }

        if(direction.x > 0)
        {
            playerSR.flipX = false;
        }
        else if(direction.x < 0)
        {
            playerSR.flipX = true;
        }
    }
}
