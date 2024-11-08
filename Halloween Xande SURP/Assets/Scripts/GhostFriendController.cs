using UnityEngine;
using UnityEngine.AI;

public class GhostFriendController : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform targetPosition;
    public Vector3 mousePos;

    public float ValueX;
    public float ValueY;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void Update()
    {
        SetAgentPosition();
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        mousePos.x = ValueX;
        ValueX = Input.GetAxis("Horizontal");
    }
    void SetAgentPosition()
    {
        agent.SetDestination(targetPosition.position);
    }
}

