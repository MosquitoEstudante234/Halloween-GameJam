using UnityEngine;

public class FallingLeaf : MonoBehaviour
{
    public float forwardSpeed = 1f;
    public float backwardSpeed = 0.5f;
    public float verticalSpeed = 1f;
    public float horizontalRange = 2f;
    public float backwardInterval = 5f;

    private float initialX;
    private float backwardTimer; 

    void Start()
    {
        initialX = transform.position.x;

        backwardTimer = backwardInterval;
    }

    void Update()
    {
        backwardTimer -= Time.deltaTime;

        transform.Translate(Vector3.right * forwardSpeed * Time.deltaTime);

        if (backwardTimer <= 0f)
        {
            transform.Translate(Vector3.left * backwardSpeed * Time.deltaTime * horizontalRange);

            backwardTimer = backwardInterval;
        }

        transform.Translate(Vector3.down * verticalSpeed * Time.deltaTime);

        if (transform.position.y <= -15f)
        {
            Destroy(gameObject);
        }
    }
}
