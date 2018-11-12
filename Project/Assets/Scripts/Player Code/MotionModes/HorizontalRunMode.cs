using System;

using UnityEngine;

using Steamy.Player.Input;

namespace Steamy.Player.MotionModes
{
    public enum HorizontalDirection
    {
        Left = 0,
        Right = 1,
    }

    [CreateAssetMenu(menuName = "Character/Locomotion/HorizontalRunMode")]
    public sealed class HorizontalRunMode : MotionMode
    {
        public float RunningForce;
        public float SpeedThreshold;

        [SerializeField]
        private new ButtonInputController ButtonController;
        [SerializeField]
        private ButtonInputController NegativeButtonController;

        private float HorizontalVelocity(Rigidbody characterRigidbody)
        {

            if (characterRigidbody != null)
            {
                return characterRigidbody.velocity.z;
            }
            throw new NullReferenceException();
        }

        public override void ApplyMotion(CharacterViewModel ViewModel)
        {
            ButtonController.CheckInput(() =>
            {
                ApplyMotionAlongDirection(ViewModel, 1);
            });

            NegativeButtonController.CheckInput(() =>
            {
                ApplyMotionAlongDirection(ViewModel, -1);
            });
        }

        private void ApplyMotionAlongDirection(CharacterViewModel playerViewModel, int Direction)
        {
            var characterRigidbody = playerViewModel.GetComponent<Rigidbody>();

            if (HorizontalVelocity(characterRigidbody) < SpeedThreshold)
            {
                Vector3 forceVector = (RunningForce * Direction) * Vector3.forward;
                characterRigidbody.AddForce(forceVector, ForceMode.Impulse);
            }
        }
    }
}
