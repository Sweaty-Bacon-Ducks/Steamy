using System;
using System.Collections.Generic;

using UnityEngine;

using Steamy.Player.MotionModes;

namespace Steamy.Player
{
    [Serializable]
    public class CharacterModel
    {
        #region Fields
        [HideInInspector]
        public CharacterViewModel ViewModel;

        public float HitPoints;
        #endregion

    }
}
