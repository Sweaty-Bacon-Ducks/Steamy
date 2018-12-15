using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Weapons/PhysicsGun")]
public class PhysicsGunModel : WeaponModel {

    public float BulletSpread;
    public int BulletCount;
    public int MagazineSize;
    public float FireRate;
    public float BulletPenetration;

    public float BulletLifeTime;
    public float BulletSpeed;

    public int BulletsInMagazine;
    public float ReloadTimer;
    public float FireTimer;
    public float TriggerTimer;
}
