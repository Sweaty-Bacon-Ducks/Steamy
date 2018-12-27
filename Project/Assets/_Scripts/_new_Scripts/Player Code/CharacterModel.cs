using System;
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
        public IDefault<CharacterHealth> HealthDefaults;
        [HideInInspector]
        public CharacterHealth Health;

        public string Name;

        public List<MotionMode> MotionModes;

        public CharacterModel() { }
    }
}

