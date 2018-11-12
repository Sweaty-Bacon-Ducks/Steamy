using System;
using System.Collections.Generic;

using UnityEngine;

using Steamy.Player.MotionModes;

namespace Steamy.Player
{
    [CreateAssetMenu(menuName = "Character/Parameters")]
    public class CharacterParameters : ScriptableObject, 
                                       ISerializationCallbackReceiver
    {
        public string Name;
        public float MaxHitPoints;

        public HashSet<MotionMode> MotionModesSet;

        private void OnEnable()
        {
            MotionModesSet = new HashSet<MotionMode>();
        }

        [SerializeField]
        private List<MotionMode> motionModesList;

        public void OnBeforeSerialize()
        {
            try
            {
                motionModesList.Clear();
                foreach (var mode in MotionModesSet)
                {
                    motionModesList.Add(mode);
                }
            }
            catch (NullReferenceException) {     }
        }

        public void OnAfterDeserialize()
        {
            try
            {
                MotionModesSet.Clear();
                foreach (var mode in motionModesList)
                {
                    MotionModesSet.Add(mode);
                }
            }
            catch (NullReferenceException) {     }
        }
    }
}
