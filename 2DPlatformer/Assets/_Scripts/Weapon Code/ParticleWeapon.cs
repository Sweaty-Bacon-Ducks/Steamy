using System;
using UnityEngine;
using UnityEngine.Networking;

public class ParticleWeapon : Weapon
{
    private const float ROTATION_OFFSET = 90f;
    [SerializeField]
    private GameObject FlamePrefab;
    [SerializeField]
    private float FlameVelocity = 6f;

    private Vector2 spawnPosition;
    private Vector3 spawnRotation;

    public override void Shoot()
    {
        if (CurrentAmmo <= 0)
        {
            StartCoroutine(Reload());
        }
        else
        {
            CurrentAmmo--;
            spawnPosition = GetComponent<Player>().info.Arm.transform.position;
            spawnRotation = GetComponent<Player>().info.Arm.transform.rotation.eulerAngles;
            var targetRotation = Quaternion.Euler(spawnRotation.x, spawnRotation.y, spawnRotation.z + ROTATION_OFFSET);
            Cmd_SpawnFireball(spawnPosition, targetRotation, FlameVelocity);
        }
    }
    [Command]
    void Cmd_SpawnFireball(Vector3 position, Quaternion rotation, float flameVelocity)
    {
        var fireball = Instantiate(FlamePrefab, position, rotation);
        fireball.GetComponent<FireballController>().Damage = Damage;
        NetworkServer.Spawn(fireball);
        fireball.GetComponent<Rigidbody2D>().velocity = (-1f) * fireball.transform.up * flameVelocity;
    }
}
