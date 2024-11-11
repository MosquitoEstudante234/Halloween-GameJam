using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AimPlayer : MonoBehaviour
{
    public SpriteRenderer playerSR;
    Vector2 playerVector;
    Transform dir;
    public GameObject gun;
    // Update is called once per frame
    void Update()
    {
        Rotate();
    }

    public void Rotate()
    {
        playerVector = PlayerMove.player.transform.position;
        Vector2 direction = (playerVector - (Vector2)gun.transform.position).normalized;
        gun.transform.right = direction;

        Vector2 scale = transform.localScale;

        transform.localScale = scale;

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
