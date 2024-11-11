using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public Transform attackPos;
    public float attackRange;
    public LayerMask playerLayer;
    
    public void Attack()
    {
        Collider2D[] hit = Physics2D.OverlapCircleAll(attackPos.position, attackRange, playerLayer);

        foreach(Collider2D player in hit)
        {
            PlayerLife.Instance.TakeDamage(1);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
