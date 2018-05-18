using System;
using UnityEngine;
using UnityEngine.Networking;

public class PhysicsWeapon : Weapon
{
    public float ThrowForce;
    public GameObject GrenadePrefab;

    private Vector2 spawnPosition;
    private Vector3 spawnRotation;

    private const float ROTATION_OFFSET = 90f;

    public void ThrowGrenade()
    {
        spawnPosition = GetComponent<Player>().info.Arm.transform.position;
        spawnRotation = GetComponent<Player>().info.Arm.transform.rotation.eulerAngles;
        var targetRotation = Quaternion.Euler(spawnRotation.x, spawnRotation.y, spawnRotation.z + ROTATION_OFFSET);
        CmdSpawnGrenade(spawnPosition, targetRotation);
    }
    [Command]
    void CmdSpawnGrenade(Vector3 position, Quaternion rotation)
    {
        var grenade = Instantiate(GrenadePrefab, position, rotation);
        NetworkServer.Spawn(grenade);
        grenade.GetComponent<Rigidbody2D>().velocity = (-1f) * grenade.transform.up * ThrowForce;
    }
}
