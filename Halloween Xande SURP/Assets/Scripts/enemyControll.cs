using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyControll : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform targetPosition;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void Update()
    {
        SetAgentPosition();
    }
    void SetAgentPosition()
    {
        agent.SetDestination(targetPosition.position);
    }
}
