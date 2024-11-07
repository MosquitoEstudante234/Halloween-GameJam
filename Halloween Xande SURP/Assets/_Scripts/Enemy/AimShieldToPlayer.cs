using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimShieldToPlayer : MonoBehaviour
{
    public SpriteRenderer playerSR;
    Vector2 playerVector;
    Transform dir;
    public GameObject gun;
    public float rotationSpeed = 2f;  // Velocidade de rotação (ajuste para mais ou menos atraso)
    private Vector2 currentDirection; // Direção atual do inimigo

    // Update is called once per frame
    void Update()
    {
        Rotate();
    }

    public void Rotate()
    {
        // Pega a posição atual do jogador
        playerVector = PlayerMove.player.transform.position;

        // Calcula a direção desejada para o inimigo (mirar no jogador)
        Vector2 targetDirection = (playerVector - (Vector2)gun.transform.position).normalized;

        // Suaviza a rotação atual em direção à direção desejada com atraso
        currentDirection = Vector2.Lerp(currentDirection, targetDirection, rotationSpeed * Time.deltaTime);

        // Aplica a direção suavizada à rotação do inimigo
        gun.transform.right = currentDirection;

        // Verifica se o inimigo precisa flipar o sprite
        Vector2 scale = transform.localScale;
        transform.localScale = scale;

        // Ajusta o flip do sprite com base no ângulo de rotação
        if (transform.eulerAngles.z > 90 && transform.eulerAngles.z < 270)
        {
            playerSR.flipX = false;
        }
        else
        {
            playerSR.flipX = true;
        }
    }
}
