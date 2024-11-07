using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MarvinState : MonoBehaviour
{
    public enum State
    {
        Atacando,
        Repouso
    }

    [SerializeField] AudioSource source;

    public State currentState;

    public float tempoEmRepouso = 3f;
    public float tempoDeAtaque = 3.3f;
    private float stateTimer;

    public Animator animator;
    BossLife life;
    public BoxCollider2D boxCollider;
    NavMeshAgent agent;
    public float maxSpeed;

    void Start()
    {
        currentState = State.Atacando;

        stateTimer = tempoDeAtaque;

        life = GetComponent<BossLife>();

        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case State.Repouso:
                agent.speed = maxSpeed;
                animator.SetBool("isAttacking", true);
                life.isInvencible = false;

                boxCollider.enabled = true;
                stateTimer -= Time.deltaTime;

                source.Play();

                if (stateTimer <= 0)
                {
                    currentState = State.Atacando;
                    stateTimer = tempoDeAtaque;
                }
                break;

            case State.Atacando:
                agent.speed = 0;
                animator.SetBool("isAttacking", false);
                life.isInvencible = false;

                boxCollider.enabled = false;
                stateTimer -= Time.deltaTime;

                if (stateTimer <= 0)
                {
                    currentState = State.Repouso;
                    stateTimer = tempoEmRepouso;
                }
                break;
        }
    }

    public void PlaySound(AudioClip clip)
    {
        source.Play();
    }
}
