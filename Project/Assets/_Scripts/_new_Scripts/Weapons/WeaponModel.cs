using System;
using System.ComponentModel;
using UnityEngine;

namespace Steamy.Weapons
{
    public class WeaponModel : INotifyPropertyChanged
    {
        private string _weaponName;
        private string _desc;
        private Sprite _weaponSprite;
        private float _damage;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this,
                    new PropertyChangedEventArgs(name)
                   );
        }

        #region Properties

        public string WeaponName
        {
            get
            {
                return _weaponName;
            }
            set
            {
                if (String.Equals(_weaponName, value))
                {
                    _weaponName = value;
                    OnPropertyChanged(nameof(WeaponName));
                }
            }
        }

        public string Desc
        {
            get
            {
                return _desc;
            }
            set
            {
                if (String.Equals(_desc, value))
                {
                    _desc = value;
                    OnPropertyChanged(nameof(WeaponName));
                }
            }
        }

        public Sprite WeaponSprite
        {
            get
            {
                return _weaponSprite;
            }
            set
            {
                if (Sprite.Equals(_weaponSprite, value))
                {
                    _weaponSprite = value;
                    OnPropertyChanged(nameof(WeaponSprite));
                }
            }
        }

        public float Damage
        {
            get
            {
                return _damage;
            }
            set
            {
                if (Math.Abs(_damage - value) > Mathf.Epsilon)
                {
                    _damage = value;
                    OnPropertyChanged(nameof(Damage));
                }
            }
        }

        #endregion
    }
}