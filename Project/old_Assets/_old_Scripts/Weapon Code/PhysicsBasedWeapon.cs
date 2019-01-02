using System;
using UnityEngine;
using UnityEngine.Networking;

public class PhysicsBasedWeapon : Weapon {

    protected const float ROTATION_OFFSET = 90f;
    [SerializeField]
    protected GameObject projectilePrefab;

    protected Vector2 spawnPosition;
    protected Vector3 spawnRotation;

    public override void Shoot()
    {
        if (CurrentAmmo <= 0)
        {
            StartCoroutine(Reload());
        }
    }

    //[Command]
    //public virtual void CmdSpawnProjectile(Vector3 position, Quaternion rotation)
    //{
        
    //}
}
