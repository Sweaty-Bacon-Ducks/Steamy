using System;
using System.ComponentModel;

using UnityEngine;
namespace Steamy.Player
{
    [CreateAssetMenu(menuName = "Character/Defaults/Health")]
    public class CharacterHealthDefault : ScriptableObject
    {
        public Sprite Icon;
        public string Name;
        public double MaxValue;

        public CharacterHealth Create()
        {
            return new CharacterHealth
            {
                Icon = Icon,
                Name = Name,
                MaxValue = MaxValue
            };
        }
    }


    [Serializable]
    public class CharacterHealth : INotifyPropertyChanged
    {
        public event Callback HealCallback;
        public event Callback DamageCallback;
        public event PropertyChangedEventHandler PropertyChanged;

        public Sprite Icon;
        public string Name;
        public double MaxValue;

        private double m_value;

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

        private bool AreEqual(double firstValue, double secondValue)
        {
            return Math.Abs(firstValue - secondValue) < Mathf.Epsilon;
        }
    }
}
