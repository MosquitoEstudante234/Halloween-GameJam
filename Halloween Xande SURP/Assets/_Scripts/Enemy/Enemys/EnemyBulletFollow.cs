using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletFollow : MonoBehaviour
{
    Transform player; 
    public float speed = 10f; 
    public float followIntensity = 0.5f;

    public ParticleSystem particula;

    public Rigidbody2D rb; 
    private Vector3 direction; 

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        direction = (player.position - transform.position).normalized;
    }

    void FixedUpdate()
    {
        Vector3 targetDirection = (player.position - transform.position).normalized;
        direction = Vector3.Lerp(direction, targetDirection, followIntensity * Time.fixedDeltaTime);

        rb.velocity = direction * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerLife.Instance.TakeDamage(1);
            Destroy(this.gameObject);
        }
        if (collision.CompareTag("Parede"))
        {
            ParticleSystem explosão = Instantiate(this.particula, new Vector3(transform.position.x, transform.position.y, -1), Quaternion.identity);
            Destroy(explosão.gameObject, 1f);
            Destroy(this.gameObject);
        }
        if (collision.CompareTag("Bullet"))
        {
            ParticleSystem explosão = Instantiate(this.particula, new Vector3(transform.position.x, transform.position.y, -1), Quaternion.identity);
            Destroy(explosão.gameObject, 1f);
            Destroy(this.gameObject);
        }
        if (collision.CompareTag("Sword"))
        {
            ParticleSystem explosão = Instantiate(this.particula, new Vector3(transform.position.x, transform.position.y, -1), Quaternion.identity);
            Destroy(explosão.gameObject, 1f);
            Destroy(this.gameObject);
        }
    }
}
