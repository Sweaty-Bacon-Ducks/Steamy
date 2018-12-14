using System;
using System.ComponentModel;
using UnityEngine;

namespace Steamy.Player
{ 
    [Serializable]
    public class CharacterHealthModel
    {
        public delegate void Callback();

        public event Callback HealCallback;
        public event Callback DamageCallback;

        public CharacterHealth Health;
        public Sprite Icon;
        public string Name;

        public void Change(double ammount)
        {
            if (IsHealing(ammount))
            {
                HealCallback();
            }
            else
            {
                DamageCallback();
            }
            Health.Value += ammount;
        }

        private bool IsHealing(double ammount)
        {
            return ammount > 0;
        }
    }

    [Serializable]
    public class CharacterHealth : INotifyPropertyChanged
    {
        private double m_value;

        public event PropertyChangedEventHandler PropertyChanged;

        public double Value
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
                }
            }
        }

        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this,
                    new PropertyChangedEventArgs(name)
                   );
        }

        private bool AreEqual(double firstValue, double secondValue)
        {
            return Math.Abs(firstValue - secondValue) < Mathf.Epsilon;
        }
    }

}
