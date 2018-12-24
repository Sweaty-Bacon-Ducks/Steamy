using UnityEngine.Networking;
using UnityEngine;

public class Grenade : PhysicsBasedWeapon {

    public float ThrowForce;

    public override void Shoot()
    {
        spawnPosition = GetComponent<Player>().info.Arm.transform.position;
        spawnRotation = GetComponent<Player>().info.Arm.transform.rotation.eulerAngles;
        var targetRotation = Quaternion.Euler(spawnRotation.x, spawnRotation.y, spawnRotation.z + ROTATION_OFFSET);
        CmdSpawnProjectile(spawnPosition, targetRotation);
    }

    [Command]
    public void CmdSpawnProjectile(Vector3 position, Quaternion rotation)
    {
        GameObject grenade = Instantiate(projectilePrefab, position, rotation);
        NetworkServer.Spawn(grenade);
        grenade.GetComponent<Rigidbody2D>().velocity = (-1f) * grenade.transform.up * ThrowForce;
    }
}
