using Steamy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapons/RaycastGun")]
public class RaycastGunDefault : WeaponDefault, IDefault<RaycastGunModel>
{
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

    public RaycastGunModel LoadFromDefaults()
    {
        return new RaycastGunModel
        {
            WeaponName = new WeaponName() { Value = WeaponName },
            Desc = new Desc() { Value = Desc },
            WeaponSprite = new WeaponSprite() { Value = WeaponSprite },
            Damage = new Damage() { Value = Damage },

            BulletSpread = new BulletSpread() { Value = BulletSpread },
            BulletCount = new BulletCount() { Value = BulletCount },
            MagazineSize = new MagazineSize() { Value = MagazineSize },
            FireRate = new FireRate() { Value = FireRate },
            BulletPenetration = new BulletPenetration() { Value = BulletPenetration },
            BulletForce = new BulletForce() { Value = BulletForce },
            ReloadTime = new ReloadTime() { Value = ReloadTime },
            TimeToFire = new TimeToFire() { Value = TimeToFire },
            RaycastLength = new RaycastLength() { Value = RaycastLength },
            ShotDuration = new ShotDuration() { Value = ShotDuration },

            FireTimer = new FireTimer() { Value = 0 },
            TriggerTimer = new TriggerTimer() { Value = 0 },
            Reloading = new Reloading() { Value = false },

            BulletsInMagazine = new BulletsInMagazine() { Value = MagazineSize },

            PenetrationDamage = new PenetrationDamage(),
            PenetrationLeft = new PenetrationLeft()
        };
    }
}
