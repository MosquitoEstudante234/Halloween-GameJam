using UnityEngine;

public class MoveAndDestroy : MonoBehaviour
{
    private float speed;

    void Start()
    {
        speed = Random.Range(70f, 120f);
    }

    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        if (transform.position.x >= 2500f)
        {
            Destroy(gameObject);
        }
    }
}
