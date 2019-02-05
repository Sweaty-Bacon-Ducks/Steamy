using System;
using System.ComponentModel;
using UnityEngine;

namespace Steamy.Weapons
{
    public class RaycastGunModel : WeaponModel
    {
        #region From ScriptableObject
        public BulletSpread BulletSpread;
        public BulletCount BulletCount;
        public MagazineSize MagazineSize;
        public FireRate FireRate;
        public BulletPenetration BulletPenetration;
        public BulletForce BulletForce;
        public ReloadTime ReloadTime;
        [Tooltip("Time between mouse click and the first shot.\n" +
                 "Consecutive shots are not affected.\n" +
                 "Resets after releasing left mouse button.")]
        public ShotChargeTime ShotChargeTime;
        #endregion

        #region Raycast unique
        public RaycastLength RaycastLength;
        public ShotDuration ShotDuration;
        #endregion

        #region Frequently changing
        public BulletsInMagazine BulletsInMagazine;
        [Tooltip("Must be >= FireRate if gun fires full auto")]
        public FireTimer FireTimer;
        [Tooltip("Time between mouse click and first shot in sequence")]
        public TriggerTimer TriggerTimer;
        [Tooltip("How much damage does the bullet after penetrating\n" +
             "the latest obstacle")]
        public PenetrationDamage PenetrationDamage;
        [Tooltip("How much penetration is left before the bullet stops")]
        public PenetrationLeft PenetrationLeft;
        public Reloading Reloading;
        #endregion
    }



    public delegate void Callback();

    public class BulletSpread : INotifyPropertyChanged
    {
        public event Callback BulletSpreadChangedCallback;
        public event PropertyChangedEventHandler PropertyChanged;

        public string Name;

        private float m_value;

        public float Value
        {
            get
            {
                return m_value;
            }
            set
            {
                if (!AreEqual(m_value, value))
                {
                    m_value = value;
                    OnPropertyChanged(Name);
                }
            }
        }

        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this,
                    new PropertyChangedEventArgs(name)
                   );
        }

        private bool AreEqual(float firstValue, float secondValue)
        {
            return Math.Abs(firstValue - secondValue) < Mathf.Epsilon;
        }
    }

    public class BulletCount : INotifyPropertyChanged
    {
        public event Callback BulletCountChangedCallback;
        public event PropertyChangedEventHandler PropertyChanged;

        public string Name;

        private int m_value;

        public int Value
        {
            get
            {
                return m_value;
            }
            set
            {
                if (!AreEqual(m_value, value))
                {
                    m_value = value;
                    OnPropertyChanged(Name);
                }
            }
        }

        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this,
                    new PropertyChangedEventArgs(name)
                   );
        }

        private bool AreEqual(int firstValue, int secondValue)
        {
            return Math.Abs(firstValue - secondValue) == 0;
        }
    }

    public class MagazineSize : INotifyPropertyChanged
    {
        public event Callback MagazineSizeChangedCallback;
        public event PropertyChangedEventHandler PropertyChanged;

        public string Name;

        private int m_value;

        public int Value
        {
            get
            {
                return m_value;
            }
            set
            {
                if (!AreEqual(m_value, value))
                {
                    m_value = value;
                    OnPropertyChanged(Name);
                }
            }
        }

        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this,
                    new PropertyChangedEventArgs(name)
                   );
        }

        private bool AreEqual(int firstValue, int secondValue)
        {
            return Math.Abs(firstValue - secondValue) == 0;
        }
    }

    public class FireRate : INotifyPropertyChanged
    {
        public event Callback FireRateChangedCallback;
        public event PropertyChangedEventHandler PropertyChanged;

        public string Name;

        private float m_value;

        public float Value
        {
            get
            {
                return m_value;
            }
            set
            {
                if (!AreEqual(m_value, value))
                {
                    m_value = value;
                    OnPropertyChanged(Name);
                }
            }
        }

        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this,
                    new PropertyChangedEventArgs(name)
                   );
        }

        private bool AreEqual(float firstValue, float secondValue)
        {
            return Math.Abs(firstValue - secondValue) < Mathf.Epsilon;
        }
    }

    public class BulletPenetration : INotifyPropertyChanged
    {
        public event Callback BulletPenetrationChangedCallback;
        public event PropertyChangedEventHandler PropertyChanged;

        public string Name;

        private float m_value;

        public float Value
        {
            get
            {
                return m_value;
            }
            set
            {
                if (!AreEqual(m_value, value))
                {
                    m_value = value;
                    OnPropertyChanged(Name);
                }
            }
        }

        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this,
                    new PropertyChangedEventArgs(name)
                   );
        }

        private bool AreEqual(float firstValue, float secondValue)
        {
            return Math.Abs(firstValue - secondValue) < Mathf.Epsilon;
        }
    }

    public class BulletForce : INotifyPropertyChanged
    {
        public event Callback BulletForceChangedCallback;
        public event PropertyChangedEventHandler PropertyChanged;

        public string Name;

        private float m_value;

        public float Value
        {
            get
            {
                return m_value;
            }
            set
            {
                if (!AreEqual(m_value, value))
                {
                    m_value = value;
                    OnPropertyChanged(Name);
                }
            }
        }

        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this,
                    new PropertyChangedEventArgs(name)
                   );
        }

        private bool AreEqual(float firstValue, float secondValue)
        {
            return Math.Abs(firstValue - secondValue) < Mathf.Epsilon;
        }
    }

    public class ReloadTime : INotifyPropertyChanged
    {
        public event Callback ReloadTimeChangedCallback;
        public event PropertyChangedEventHandler PropertyChanged;

        public string Name;

        private float m_value;

        public float Value
        {
            get
            {
                return m_value;
            }
            set
            {
                if (!AreEqual(m_value, value))
                {
                    m_value = value;
                    OnPropertyChanged(Name);
                }
            }
        }

        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this,
                    new PropertyChangedEventArgs(name)
                   );
        }

        private bool AreEqual(float firstValue, float secondValue)
        {
            return Math.Abs(firstValue - secondValue) < Mathf.Epsilon;
        }
    }

    public class ShotChargeTime : INotifyPropertyChanged
    {
        public event Callback TimeToFireChangedCallback;
        public event PropertyChangedEventHandler PropertyChanged;

        public string Name;

        private float m_value;

        public float Value
        {
            get
            {
                return m_value;
            }
            set
            {
                if (!AreEqual(m_value, value))
                {
                    m_value = value;
                    OnPropertyChanged(Name);
                }
            }
        }

        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this,
                    new PropertyChangedEventArgs(name)
                   );
        }

        private bool AreEqual(float firstValue, float secondValue)
        {
            return Math.Abs(firstValue - secondValue) < Mathf.Epsilon;
        }
    }

    public class RaycastLength : INotifyPropertyChanged
    {
        public event Callback RaycastLengthChangedCallback;
        public event PropertyChangedEventHandler PropertyChanged;

        public string Name;

        private float m_value;

        public float Value
        {
            get
            {
                return m_value;
            }
            set
            {
                if (!AreEqual(m_value, value))
                {
                    m_value = value;
                    OnPropertyChanged(Name);
                }
            }
        }

        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this,
                    new PropertyChangedEventArgs(name)
                   );
        }

        private bool AreEqual(float firstValue, float secondValue)
        {
            return Math.Abs(firstValue - secondValue) < Mathf.Epsilon;
        }
    }

    public class ShotDuration : INotifyPropertyChanged
    {
        public event Callback ShotDurationChangedCallback;
        public event PropertyChangedEventHandler PropertyChanged;

        public string Name;

        private float m_value;

        public float Value
        {
            get
            {
                return m_value;
            }
            set
            {
                if (!AreEqual(m_value, value))
                {
                    m_value = value;
                    OnPropertyChanged(Name);
                }
            }
        }

        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this,
                    new PropertyChangedEventArgs(name)
                   );
        }

        private bool AreEqual(float firstValue, float secondValue)
        {
            return Math.Abs(firstValue - secondValue) < Mathf.Epsilon;
        }
    }

    public class BulletsInMagazine : INotifyPropertyChanged
    {
        public event Callback BulletsInMagazineChangedCallback;
        public event PropertyChangedEventHandler PropertyChanged;

        public string Name;

        private int m_value;

        public int Value
        {
            get
            {
                return m_value;
            }
            set
            {
                if (!AreEqual(m_value, value))
                {
                    m_value = value;
                    OnPropertyChanged(Name);
                }
            }
        }

        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this,
                    new PropertyChangedEventArgs(name)
                   );
        }

        private bool AreEqual(int firstValue, int secondValue)
        {
            return Math.Abs(firstValue - secondValue) < Mathf.Epsilon;
        }
    }

    public class FireTimer : INotifyPropertyChanged
    {
        public event Callback FireTimerChangedCallback;
        public event PropertyChangedEventHandler PropertyChanged;

        public string Name;

        private float m_value;

        public float Value
        {
            get
            {
                return m_value;
            }
            set
            {
                if (!AreEqual(m_value, value))
                {
                    m_value = value;
                    OnPropertyChanged(Name);
                }
            }
        }

        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this,
                    new PropertyChangedEventArgs(name)
                   );
        }

        private bool AreEqual(float firstValue, float secondValue)
        {
            return Math.Abs(firstValue - secondValue) < Mathf.Epsilon;
        }
    }

    public class TriggerTimer : INotifyPropertyChanged
    {
        public event Callback TriggerTimerChangedCallback;
        public event PropertyChangedEventHandler PropertyChanged;

        public string Name;

        private float m_value;

        public float Value
        {
            get
            {
                return m_value;
            }
            set
            {
                if (!AreEqual(m_value, value))
                {
                    m_value = value;
                    OnPropertyChanged(Name);
                }
            }
        }

        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this,
                    new PropertyChangedEventArgs(name)
                   );
        }

        private bool AreEqual(float firstValue, float secondValue)
        {
            return Math.Abs(firstValue - secondValue) < Mathf.Epsilon;
        }
    }

    /// <summary>
    /// How much damage does the bullet after penetrating the latest obstacle.
    /// Don't modify this, it gets reseted and modified in RaycastGunViewModel.ExecuteAttack only
    /// </summary>
    public class PenetrationDamage : INotifyPropertyChanged
    {
        public event Callback PenetrationDamageChangedCallback;
        public event PropertyChangedEventHandler PropertyChanged;

        public string Name;

        private float m_value;

        public float Value
        {
            get
            {
                return m_value;
            }
            set
            {
                if (!AreEqual(m_value, value))
                {
                    m_value = value;
                    OnPropertyChanged(Name);
                }
            }
        }

        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this,
                    new PropertyChangedEventArgs(name)
                   );
        }

        private bool AreEqual(float firstValue, float secondValue)
        {
            return Math.Abs(firstValue - secondValue) < Mathf.Epsilon;
        }
    }

    /// <summary>
    /// How much penetration is left before the bullet stops.
    /// Don't modify this, it gets reseted and modified in RaycastGunViewModel.ExecuteAttack only.
    /// </summary>
    public class PenetrationLeft : INotifyPropertyChanged
    {
        public event Callback PenetrationLeftChangedCallback;
        public event PropertyChangedEventHandler PropertyChanged;

        public string Name;

        private float m_value;

        public float Value
        {
            get
            {
                return m_value;
            }
            set
            {
                if (!AreEqual(m_value, value))
                {
                    m_value = value;
                    OnPropertyChanged(Name);
                }
            }
        }

        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this,
                    new PropertyChangedEventArgs(name)
                   );
        }

        private bool AreEqual(float firstValue, float secondValue)
        {
            return Math.Abs(firstValue - secondValue) < Mathf.Epsilon;
        }
    }

    public class Reloading : INotifyPropertyChanged
    {
        public event Callback ReloadingChangedCallback;
        public event PropertyChangedEventHandler PropertyChanged;

        public string Name;

        private bool m_value;

        public bool Value
        {
            get
            {
                return m_value;
            }
            set
            {
                if (!AreEqual(m_value, value))
                {
                    m_value = value;
                    OnPropertyChanged(Name);
                }
            }
        }

        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this,
                    new PropertyChangedEventArgs(name)
                   );
        }

        private bool AreEqual(bool firstValue, bool secondValue)
        {
            return firstValue == secondValue;
        }
    }
}

