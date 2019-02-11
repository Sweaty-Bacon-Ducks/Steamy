using System;
using System.ComponentModel;

using UnityEngine;

using Steamy;

namespace Steamy.Player
{
    [CreateAssetMenu(menuName = "Character/Defaults/Health")]
    public class CharacterHealthDefault : ScriptableObject, IDefault<CharacterHealth>
    {
        public Sprite Icon;
        public string Name;
        public double MaxValue;

        public CharacterHealth LoadFromDefaults()
        {
            return new CharacterHealth
            {
                Icon = Icon,
                Name = Name,
                MaxValue = MaxValue,

                Value = MaxValue
            };
        }
    }
}
