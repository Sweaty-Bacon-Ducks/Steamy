using UnityEngine.Networking;
using UnityEngine;

public class Flamethrower : PhysicsBasedWeapon {

    [SerializeField]
    private float flameVelocity = 6f;

    public override void Shoot()
    {
        if (CurrentAmmo >= 1)
        {
            CurrentAmmo--;
            spawnPosition = GetComponent<Player>().info.Arm.transform.position;
            spawnRotation = GetComponent<Player>().info.Arm.transform.rotation.eulerAngles;
            var targetRotation = Quaternion.Euler(spawnRotation.x, spawnRotation.y, spawnRotation.z + ROTATION_OFFSET);
            CmdSpawnProjectile(spawnPosition, targetRotation);
        }
    }

    [Command]
    public void CmdSpawnProjectile(Vector3 position, Quaternion rotation)
    {
        GameObject projectile = Instantiate(projectilePrefab, position, rotation);
        projectile.GetComponent<FireballController>().Damage = Damage;
        NetworkServer.Spawn(projectile);
        projectile.GetComponent<Rigidbody2D>().velocity = (-1f) * projectile.transform.up * flameVelocity;
    }
}
