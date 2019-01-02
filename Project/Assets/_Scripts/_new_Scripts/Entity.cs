using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// TMP script for shooting
/// </summary>
public class Entity : MonoBehaviour {

    public float Health;
    public float PenetrationResistance;
    public float PenetrationDamageReduction;

    public void ReceiveDamage(float damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
