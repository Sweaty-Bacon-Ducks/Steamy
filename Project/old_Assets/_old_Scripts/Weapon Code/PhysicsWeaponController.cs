using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PhysicsWeaponController : NetworkBehaviour
{
    public float ExplosionRadius;
    public float ExplosionDelay;
    public float MaxExplosionForce;
    public float MaxDamage;
    public GameObject ExplosionPrefab;

    private float countdown;
    private bool hasExploded;

    void Awake()
    {
        countdown = ExplosionDelay;
    }

    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0f && hasExploded == false)
        {
            Explode();
            hasExploded = true;
        }
    }

    private void Explode()
    {
        var nearbyColliders = Physics2D.OverlapCircleAll(transform.position, ExplosionRadius);
        foreach (Collider2D nearbyCollider in nearbyColliders)
        {
            Rigidbody2D rb = nearbyCollider.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                ApplyExplosionForce(rb);
                if (rb.tag == "Player")
                {
                    DealExplosionDamage(rb);
                }
            }

        }
        var explosion = Instantiate(ExplosionPrefab, transform.position, transform.rotation);
        NetworkServer.Spawn(explosion);
        NetworkServer.Destroy(gameObject);
    }
    private void DealExplosionDamage(Rigidbody2D rb)
    {
        float damage = CalculateEffectValue(rb.transform.position, MaxDamage);
        string _playerID = rb.transform.name;
        rb.gameObject.GetComponent<Player>().Cmd_PlayerShot(_playerID, damage);
    }
    private void ApplyExplosionForce(Rigidbody2D rb)
    {
        float explosionForce = CalculateEffectValue(rb.transform.position, MaxExplosionForce);
        Vector2 forceVector = rb.transform.position - transform.position;
        //rb.AddForce(forceVector.normalized * explosionForce, ForceMode2D.Impulse);
    }
    private float CalculateEffectValue(Vector3 objectPosition, float maxEffectValue)
    {
        float distanceToObject = Math.Abs((transform.position - objectPosition).magnitude);
        float effectValue = maxEffectValue / distanceToObject;
        return effectValue;
    }
}
