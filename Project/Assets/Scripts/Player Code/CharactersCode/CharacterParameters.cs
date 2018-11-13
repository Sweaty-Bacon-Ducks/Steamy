using System;
using System.Collections.Generic;

using UnityEngine;

using Steamy.Player.MotionModes;

namespace Steamy.Player
{
    [CreateAssetMenu(menuName = "Character/Parameters")]
    public class CharacterParameters : ScriptableObject
    {
        public string Name;
        public float MaxHitPoints;
        public List<MotionMode> MotionModes;
    }
}
