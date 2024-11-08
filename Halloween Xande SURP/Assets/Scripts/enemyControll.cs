using UnityEngine;
using UnityEngine.AI;

public class enemyControll : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform targetPosition;

    public float life;
    public float damage;

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
