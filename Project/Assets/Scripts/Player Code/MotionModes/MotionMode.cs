using System;

using UnityEngine;

using Steamy.Player.Input;

namespace Steamy.Player.MotionModes
{
    public class MotionMode : ScriptableObject
    {
        public string Name;

        [NonSerialized]
        protected ButtonInputController ButtonController;

        public virtual void ApplyMotion(CharacterViewModel ViewModel)
        {
            ButtonController.CheckInput(() =>
            {
                Debug.Log("Applying motion: " + ViewModel.Parameters.MotionModesSet.Count);
                _ApplyMotion(ViewModel);
            });
        }

        protected virtual void _ApplyMotion(CharacterViewModel playerViewModel) {   }

        public override bool Equals(object obj)
        {
            var motionMode = obj as MotionMode;
            return this.Name.Equals(motionMode.Name);
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}
