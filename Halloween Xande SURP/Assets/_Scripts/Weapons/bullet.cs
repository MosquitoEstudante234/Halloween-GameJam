using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float spd = 20f;
    public Rigidbody2D rb;
    public int dano;
    public int danoInimigo;

    public ParticleSystem particula;

    public static bullet Instance;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        rb.velocity = transform.right * spd;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            ParticleSystem explosão = Instantiate(this.particula, new Vector3(transform.position.x, transform.position.y, -1), Quaternion.identity);
            Destroy(explosão.gameObject, 1f);
            Destroy(this.gameObject);
        }
        if (collision.CompareTag("Parede"))
        {
            ParticleSystem explosão = Instantiate(this.particula, new Vector3(transform.position.x, transform.position.y, -1), Quaternion.identity);
            Destroy(explosão.gameObject, 1f);
            Destroy(this.gameObject);
        }
    }
}
