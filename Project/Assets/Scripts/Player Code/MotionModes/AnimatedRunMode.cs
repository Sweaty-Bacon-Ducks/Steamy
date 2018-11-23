using System;
using UnityEngine;

namespace Steamy.Player.MotionModes
{
    [CreateAssetMenu(menuName = "MotionModes/AnimatedRunMode")]
    public class AnimatedRunMode : MotionMode
    {
        public string AxisName;
        public float AxisDeadzone;

        public float Acceleration;
        public float Deceleration;

		public const float LOG_OFFSET = 1.05f;

        public string AnimationSpeedVariable;

        private const float MAX_AXIS_VALUE = 1f;

        private float HorizontalVelocity(Rigidbody characterRigidbody)
        {
            return Mathf.Abs(characterRigidbody.velocity.x);
        }

        protected float SpeedUp(float currentSpeed)
        {
            float newSpeed = currentSpeed + 1f/(currentSpeed+100f) + Time.fixedDeltaTime * Acceleration;
            return Mathf.Clamp01(newSpeed);
        }

        protected float SlowDown(float currentSpeed)
        {
            float newSpeed = currentSpeed - Deceleration * Time.deltaTime;
                                                               return Mathf.Clamp01(newSpeed);
        }

        public override void ApplyMotion(CharacterViewModel characterViewModel)
        {
            var characterRigidbody = characterViewModel.GetComponent<Rigidbody>();
            {
                var animator = characterViewModel.GetComponent<Animator>();
                var currentSpeed = animator.GetFloat(AnimationSpeedVariable);
                if (Mathf.Abs(Input.GetAxis(AxisName) - MAX_AXIS_VALUE) < AxisDeadzone)
                {
                    animator.SetFloat(AnimationSpeedVariable, SpeedUp(currentSpeed));
                }
                else
                {
                    animator.SetFloat(AnimationSpeedVariable, SlowDown(currentSpeed));
                }
            }
        }
    }
}

