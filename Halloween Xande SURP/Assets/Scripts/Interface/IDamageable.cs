using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    public void Damage(float damage);
    public void Die();
    public float _maxLife { get; set;}
    public float _curLife { get; set;}
}
