using Steamy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Steamy.Weapons
{
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
        public float ShotChargeTime;

        public float RaycastLength;
        public float ShotDuration;

        public RaycastGunModel LoadFromDefaults()
        {
            return new RaycastGunModel
            {
                WeaponName = WeaponName,
                Desc = Desc,
                WeaponSprite = WeaponSprite,
                Damage = Damage,

                BulletSpread = BulletSpread,
                BulletCount = BulletCount,
                MagazineSize = MagazineSize,
                FireRate = FireRate,
                BulletPenetration = BulletPenetration,
                BulletForce = BulletForce,
                ReloadTime = ReloadTime,
                ShotChargeTime = ShotChargeTime,
                RaycastLength = RaycastLength,
                ShotDuration = ShotDuration,

                FireTimer = 0f,
                ShotChargeTimer = 0f,
                Reloading = false,

                BulletsInMagazine = MagazineSize, 
            };
        }
    }
}

