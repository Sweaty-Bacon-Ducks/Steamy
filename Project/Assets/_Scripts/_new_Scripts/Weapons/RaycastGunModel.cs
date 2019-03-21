using System;
using System.ComponentModel;
using UnityEngine;

namespace Steamy.Weapons
{
    public class RaycastGunModel : WeaponModel
    {
        #region From ScriptableObject
        private float _bulletSpread;
        private int _bulletCount;
        private int _magazineSize;
        private float _fireRate;
        private float _bulletPenetration;
        private float _bulletForce;
        private float _reloadTime;
        [Tooltip("Time between mouse click and the first shot.\n" +
                 "Consecutive shots are not affected.\n" +
                 "Resets after releasing left mouse button.")]
        private float _shotChargeTime;
        #endregion

        #region Raycast unique
        private float _raycastLength;
        private float _shotDuration;
        #endregion

        #region Frequently changing
        private int _bulletsInMagazine;
        [Tooltip("Must be >= FireRate if gun fires full auto")]
        private float _fireTimer;
        [Tooltip("Time between mouse click and first shot in sequence")]
        private float _shotChargeTimer;
        [Tooltip("How much damage does the bullet after penetrating\n" +
             "the latest obstacle")]
        private float _penetrationDamage;
        [Tooltip("How much penetration is left before the bullet stops")]
        private float _penetrationLeft;
        private bool _reloading;
        #endregion

        #region Properties
        public float BulletSpread
        {
            get
            {
                return _bulletSpread;
            }
            set
            {
                if (Math.Abs(_bulletSpread - value) > Mathf.Epsilon)
                {
                    _bulletSpread = value;
                    OnPropertyChanged(nameof(BulletSpread));
                }
            }
        }

        public int BulletCount
        {
            get
            {
                return _bulletCount;
            }
            set
            {
                if (Math.Abs(_bulletCount - value) != 0)
                {
                    _bulletCount = value;
                    OnPropertyChanged(nameof(BulletCount));
                }
            }
        }

        public int MagazineSize
        {
            get
            {
                return _magazineSize;
            }
            set
            {
                if (Math.Abs(_magazineSize - value) != 0)
                {
                    _magazineSize = value;
                    OnPropertyChanged(nameof(MagazineSize));
                }
            }
        }

        public float FireRate
        {
            get
            {
                return _fireRate;
            }
            set
            {
                if (Math.Abs(_fireRate - value) > Mathf.Epsilon)
                {
                    _fireRate = value;
                    OnPropertyChanged(nameof(FireRate));
                }
            }
        }

        public float BulletPenetration
        {
            get
            {
                return _bulletPenetration;
            }
            set
            {
                if (Math.Abs(_bulletPenetration - value) > Mathf.Epsilon)
                {
                    _bulletPenetration = value;
                    OnPropertyChanged(nameof(BulletPenetration));
                }
            }
        }

        public float BulletForce
        {
            get
            {
                return _bulletForce;
            }
            set
            {
                if (Math.Abs(_bulletForce - value) > Mathf.Epsilon)
                {
                    _bulletForce = value;
                    OnPropertyChanged(nameof(BulletForce));
                }
            }
        }

        public float ReloadTime
        {
            get
            {
                return _reloadTime;
            }
            set
            {
                if (Math.Abs(_reloadTime - value) > Mathf.Epsilon)
                {
                    _reloadTime = value;
                    OnPropertyChanged(nameof(ReloadTime));
                }
            }
        }

        public float ShotChargeTime
        {
            get
            {
                return _shotChargeTime;
            }
            set
            {
                if (Math.Abs(_shotChargeTime - value) > Mathf.Epsilon)
                {
                    _shotChargeTime = value;
                    OnPropertyChanged(nameof(ShotChargeTime));
                }
            }
        }

        public float RaycastLength
        {
            get
            {
                return _raycastLength;
            }
            set
            {
                if (Math.Abs(_raycastLength - value) > Mathf.Epsilon)
                {
                    _raycastLength = value;
                    OnPropertyChanged(nameof(RaycastLength));
                }

                _raycastLength = value;
            }
        }

        public float ShotDuration
        {
            get
            {
                return _shotDuration;
            }
            set
            {
                if (Math.Abs(_shotDuration - value) > Mathf.Epsilon)
                {
                    _shotDuration = value;
                    OnPropertyChanged(nameof(ShotDuration));
                }
            }
        }

        public int BulletsInMagazine
        {
            get
            {
                return _bulletsInMagazine;
            }
            set
            {
                if (Math.Abs(_bulletsInMagazine - value) != 0)
                {
                    _bulletsInMagazine = value;
                    OnPropertyChanged(nameof(BulletsInMagazine));
                }
            }
        }

        public float FireTimer
        {
            get
            {
                return _fireTimer;
            }
            set
            {
                if (Math.Abs(_fireTimer - value) > Mathf.Epsilon)
                {
                    _fireTimer = value;
                    OnPropertyChanged(nameof(FireTimer));
                }
            }
        }

        public float ShotChargeTimer
        {
            get
            {
                return _shotChargeTimer;
            }
            set
            {
                if (Math.Abs(_shotChargeTimer - value) > Mathf.Epsilon)
                {
                    _shotChargeTimer = value;
                    OnPropertyChanged(nameof(ShotChargeTimer));
                }
            }
        }

        public float PenetrationDamage
        {
            get
            {
                return _penetrationDamage;
            }
            set
            {
                if (Math.Abs(_penetrationDamage - value) > Mathf.Epsilon)
                {
                    _penetrationDamage = value;
                    OnPropertyChanged(nameof(PenetrationDamage));
                }
            }
        }

        public float PenetrationLeft
        {
            get
            {
                return _penetrationLeft;
            }
            set
            {
                if (Math.Abs(_penetrationLeft - value) > Mathf.Epsilon)
                {
                    _penetrationLeft = value;
                    OnPropertyChanged(nameof(PenetrationLeft));
                }
            }
        }

        public bool Reloading
        {
            get
            {
                return _reloading;
            }
            set
            {
                if (_reloading != value)
                {
                    _reloading = value;
                    OnPropertyChanged(nameof(Reloading));
                }
            }
        }

        #endregion
    }
}


