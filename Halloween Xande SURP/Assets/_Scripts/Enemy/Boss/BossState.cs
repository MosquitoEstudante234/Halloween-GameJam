using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossState : MonoBehaviour
{
    enum State { Follow, Attack}
    NavMeshAgent agent;
    State currentState;
    public Animator anim;

    public float attackDistance;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        switch(currentState)
        {
            case State.Follow:
                FollowPlayer();
                break;
            case State.Attack:
                AttackPlayer();
                break;
        }
        ChangeState();
    }

    void FollowPlayer()
    {
        agent.SetDestination(PlayerMove.player.transform.position);
        anim.SetBool("isWalking", true);
        anim.SetBool("isAttacking", false);
    }

    void AttackPlayer()
    {
        agent.ResetPath();
        anim.SetBool("isWalking", false);
        anim.SetBool("isAttacking", true);
    }

    void ChangeState()
    {
        float playerDistance = Vector3.Distance(transform.position, PlayerMove.player.transform.position);

        if(playerDistance <= attackDistance)
        {
            currentState = State.Attack;
        }
        else
        {
            currentState = State.Follow;
        }
    }
}
