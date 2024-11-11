using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWork : MonoBehaviour
{
    public float spd = 20f;
    public Rigidbody2D rb;
    public int dano;
    public int danoInimigo;

    public ParticleSystem particula;
    RadialSpread radialSpread; 
    Animator animator;
    public static FireWork instance;

    private void Awake()
    {
        instance = this;
        radialSpread = GetComponent<RadialSpread>();
        animator = GetComponent<Animator>();
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
            animator.SetTrigger("Explode");
        }
        if (collision.CompareTag("Parede"))
        {
            ParticleSystem explosão = Instantiate(this.particula, new Vector3(transform.position.x, transform.position.y, -1), Quaternion.identity);
            Destroy(explosão.gameObject, 1f);
            animator.SetTrigger("Explode");
        }
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
