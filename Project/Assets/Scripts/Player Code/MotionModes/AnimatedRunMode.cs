using System;
using UnityEngine;

namespace Steamy.Player.MotionModes
{
    [CreateAssetMenu(menuName = "MotionModes/AnimatedRunMode")]
    public class AnimatedRunMode : MotionMode
    {
        public string AxisName;
        public float Acceleration;
        public float SpeedThreshold;

        public string AnimationSpeedVariable;

        private float HorizontalVelocity(Rigidbody characterRigidbody)
        {
            return Mathf.Abs(characterRigidbody.velocity.x);
        }

        private float RELU(float value)
        {
            return value > 0 ? value : 0;
        }

        protected float SpeedUp(float currentSpeed)
        {
            float newSpeed = currentSpeed + Acceleration * Mathf.Log(Time.deltaTime + 1, (float)Math.E);
            return newSpeed < 1 ? newSpeed : 0.99f;
        }

        protected float SlowDown(float currentSpeed)
        {
            return RELU(currentSpeed - Acceleration * Time.deltaTime) ;
        }

        public override void ApplyMotion(CharacterViewModel characterViewModel)
        {
            var characterRigidbody = characterViewModel.GetComponent<Rigidbody>();
            if (HorizontalVelocity(characterRigidbody) - SpeedThreshold <= 0)
            {
                Debug.Log("Velocity check");
                var animator = characterViewModel.GetComponent<Animator>();
                var currentSpeed = animator.GetFloat(AnimationSpeedVariable);
                if (Input.GetAxis(AxisName) > 0)
                {
                    Debug.Log("Applying motion");

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

