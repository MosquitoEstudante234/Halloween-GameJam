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
public class enemyControll : MonoBehaviour, IDamageable
{
    NavMeshAgent agent;
    public SlimeSplit Slime;
    public GameObject Cura;

    public Transform targetPosition;
    public UnityEvent OnDamage;
    public SpriteType spriteType;

    public bool inverted;

    public float damage = 1f;

    [field: SerializeField] public float _maxLife { get; set; } = 3f;
    [field: SerializeField] public float _curLife { get ; set ; }

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        targetPosition = FindObjectOfType<PlayerControler>().GetComponent<Transform>();
        Scene scene = SceneManager.GetActiveScene();
    }

    private void Start()
    {
        _curLife = _maxLife;
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
    private void OnParticleCollision(GameObject other)
    {
        Damage(damage);
        if (gameObject.GetComponent<SlimeSplit>())
        {
            if(_curLife <= 0)
            {
                gameObject.GetComponent<SlimeSplit>().RandomGenerator();
            }
            return;
        }
        if (_curLife <= 0)
        {
            CureDrop();
            Die();
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

    public void Damage(float damag)
    {
        damag = damage;
        _curLife -= damag;

        agent.enabled = false;
        OnDamage.Invoke();
        StartCoroutine(StopTime());
    }

    public void Die()
    {
        Missions.Instance.UpdateText();
        Destroy(gameObject);
    }
}