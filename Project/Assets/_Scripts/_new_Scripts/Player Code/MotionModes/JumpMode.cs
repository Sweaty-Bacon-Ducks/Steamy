using System;

using UnityEngine;

namespace Steamy.Player.MotionModes
{
    [CreateAssetMenu(menuName = "MotionModes/JumpMode")]
    public sealed class JumpMode : MotionMode
    {
        public string AxisName;
        public float AxisDeadzone;

        public float Acceleration;
        public float Deceleration;
        public float SpeedMultiplier;
        public float SpeedThreshold;

        public string AnimationSpeedVariable;

        private const float MAX_AXIS_VALUE = 1f;

        public override void ApplyMotion(CharacterViewModel characterViewModel)
        {
            var characterRigidbody = characterViewModel.GetComponent<Rigidbody>();
            var playerInput = Input.GetAxis(AxisName);

            var animator = characterViewModel.GetComponent<Animator>();
            var currentAnimationSpeed = animator.GetFloat(AnimationSpeedVariable);

            float currentVelocity = characterRigidbody.velocity.y;
            float newVelocity = 0;
            float newAnimationSpeed = 0;
            if (InputInRange(playerInput) && characterRigidbody.velocity.y < 0.1f)
            {
                //newAnimationSpeed = Mathf.Clamp01(currentAnimationSpeed + Time.deltaTime * Acceleration);
                //newVelocity = currentVelocity + playerInput * SpeedMultiplier * Time.deltaTime * Acceleration;
                newVelocity = currentVelocity + 5f;
            }
            else
            {
                //newAnimationSpeed = Mathf.Clamp01(currentAnimationSpeed - Time.deltaTime * Deceleration);
				//var interpolationFactor = Mathf.Clamp01(SpeedMultiplier * Time.deltaTime * Deceleration);
				//newVelocity = Mathf.Lerp(currentVelocity, 0f, interpolationFactor);
                newVelocity = currentVelocity;
            }

			//if (SpeedInRange(newVelocity))
			//{
            //Debug.Log(canJump);
		    UpdateVerticalVelocity(characterRigidbody, newVelocity);
			//}
			//animator.SetFloat(AnimationSpeedVariable, newAnimationSpeed);
        }
        private float VerticalVelocity(Rigidbody characterRigidbody)
        {
            return Mathf.Abs(characterRigidbody.velocity.y);
        }

        private bool InputInRange(float playerInput)
        {
            return Mathf.Abs(playerInput) > MAX_AXIS_VALUE - AxisDeadzone;
        }

        private bool SpeedInRange(float playerSpeed)
        {
            return Mathf.Abs(playerSpeed) < SpeedThreshold;
        }

        private void UpdateVerticalVelocity(Rigidbody characterRigidbody, float verticalVelocity)
        {
            characterRigidbody.velocity = new Vector3(characterRigidbody.velocity.x, verticalVelocity, characterRigidbody.velocity.z);
        }

        private bool AreEqual(float firstValue, float secondValue)
        {
            return Mathf.Abs(firstValue - secondValue) < Mathf.Epsilon;
        }

        
    }
		
    
    
}
