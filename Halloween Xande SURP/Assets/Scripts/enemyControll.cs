using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;


public enum SpriteType
{
    normal, inverted
}
public class enemyControll : MonoBehaviour
{
    NavMeshAgent agent;
    public SlimeSplit Slime;
    public GameObject Cura;

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
        targetPosition = FindObjectOfType<PlayerControler>().GetComponent<Transform>();
        Scene scene = SceneManager.GetActiveScene();
    }

    private void Update()
    {
        SetAgentPosition();
        if (gameObject.transform.position.x >= targetPosition.transform.position.x)
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
        if (gameObject.GetComponent<SlimeSplit>())
        {
            if(life <= 0)
            {
                gameObject.GetComponent<SlimeSplit>().RandomGenerator();
            }
            return;
        }
        if (life <= 0)
        {
            CureDrop();
            Destroy(gameObject);
        }
    }

    IEnumerator StopTime()
    {
        yield return new WaitForSeconds(.3f);
        agent.enabled = true;
    }

    public void CureDrop()
    {
        int RandomValue = Random.Range(0, 2);
        print(RandomValue);

        switch (RandomValue)
        {
            case 0:
                break;
            case 1:
                Instantiate(Cura, gameObject.transform.position, Quaternion.identity);
                break;
        }
    }
}