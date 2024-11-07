using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWork2 : MonoBehaviour
{
    public int dano;
    public ParticleSystem particula;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
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
