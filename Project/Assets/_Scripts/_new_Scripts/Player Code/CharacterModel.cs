﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using Steamy.Player.MotionModes;
using UnityEngine;

namespace Steamy.Player
{
    public delegate void Callback();

    [Serializable]
    public class CharacterModel
    { 
        public CharacterHealthDefault HealthDefaults;
        [HideInInspector]
        public CharacterHealth Health;

        public string Name;

        public List<MotionMode> MotionModes;

        public CharacterModel() { }
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
