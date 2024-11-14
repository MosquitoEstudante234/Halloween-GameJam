using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.UIElements;


public enum SpriteType
{
    normal, inverted
}
public class enemyControll : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform targetPosition;
    public UnityEvent OnDamage;
    public SpriteType spriteType;

    public bool inverted;

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
        if(gameObject.transform.position.x >= targetPosition.transform.position.x)
        {
            switch (spriteType)
            {
                case SpriteType.normal:
                    gameObject.GetComponent<SpriteRenderer>().flipX = true;
                    break;
                case SpriteType.inverted:
                    gameObject.GetComponent<SpriteRenderer>().flipX = false;
                    break;

            }
        }
        else
        {
            switch (spriteType)
            {
                case SpriteType.normal:
                    gameObject.GetComponent<SpriteRenderer>().flipX = false;
                    break;
                case SpriteType.inverted:
                    gameObject.GetComponent<SpriteRenderer>().flipX = true;
                    break;
            }
        }
    }
    void SetAgentPosition()
    {
        agent.SetDestination(targetPosition.position);
    }
    void Damage()
    {
        life -= damage;
        agent.enabled = false;
        OnDamage.Invoke();
        StartCoroutine(StopTime());
    }
    private void OnParticleCollision(GameObject other)
    {
        Damage();
        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator StopTime()
    {
        yield return new WaitForSeconds(.3f);
        agent.enabled = true;
    }
}
