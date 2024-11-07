using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using EZCameraShake;

public class RadialSpread : MonoBehaviour
{
    [Header("Projeteis")]
    public int numberOfProjectiles;
    public GameObject bulletPrefab;
    [Header("Priavte Variables")]
    private Vector3 startPoint = Vector3.zero;
    public const float radius = 1f;
    public Transform point;
    public int safado;
    public AudioSource source;

    private void Start()
    {
        startPoint = point.position;
    }

    public void SpawnProjectiles(int min)
    {
        source.Play();
        int max = 60;
        int numberOfProjectiles = Random.Range(min, max);
        CameraShaker.Instance.ShakeOnce(1f, 1f, 0.2f, 0.2f);
        for (int i = 0; i < numberOfProjectiles; i++)
        {
            // Calcula o ângulo para cada bala
            float angle = i * (360f / numberOfProjectiles);
            // Converte o ângulo para radianos
            float angleRad = angle * Mathf.Deg2Rad;

            // Calcula a direção da bala com base no ângulo
            Vector2 direction = new Vector2(Mathf.Cos(angleRad), Mathf.Sin(angleRad));

            // Instancia a bala na posição atual
            GameObject bullet = Instantiate(bulletPrefab, point.position, Quaternion.identity);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = direction * 6;
            }
        }
    }
}
