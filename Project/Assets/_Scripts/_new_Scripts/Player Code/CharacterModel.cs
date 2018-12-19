using System;
using System.ComponentModel;
using System.Collections.Generic;

using Steamy.Player.MotionModes;

using UnityEngine;

namespace Steamy.Player
{
	[Serializable]
	public class CharacterModel
	{
        public string Name;
        public CharacterHealth Health;

        public CharacterModel() { }

        public List<MotionMode> MotionModes;
	}

    [Serializable]
    public class CharacterHealth : INotifyPropertyChanged
    {
        public delegate void Callback();

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

