using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapons/RaycastGun")]
public class RaycastGunModel : WeaponModel {

    public float BulletSpread;
    public int BulletCount;
    public int MagazineSize;
    public float FireRate;
    public float BulletPenetration;
    public float BulletForce;
    public float ReloadTime;

    [Tooltip("Time between mouse click and the first shot.\n" +
             "Consecutive shots are not affected.\n" +
             "Resets after releasing left mouse button.")]
    public float TimeToFire;

    public float RaycastLength;
    public float ShotDuration;
}
