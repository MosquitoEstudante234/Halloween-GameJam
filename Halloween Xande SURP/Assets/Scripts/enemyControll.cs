using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class enemyControll : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform targetPosition;

    public float life = 3f;
    public float damage = 1f;

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
    void Damage()
    {
        life -= damage;
    }
    private void OnParticleCollision(GameObject other)
    {
        Damage();
        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }
}
