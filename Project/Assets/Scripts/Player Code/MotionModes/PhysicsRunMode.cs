using System;

using UnityEngine;

namespace Steamy.Player.MotionModes
{
    [CreateAssetMenu(menuName = "MotionModes/PhysicsRunMode")]
	public sealed class PhysicsRunMode : MotionMode
	{
		public string AxisName;
		public float RunningForce;
        public float SpeedThreshold;

        private float HorizontalVelocity(Rigidbody characterRigidbody)
		{
			return characterRigidbody.velocity.x;
		}

		public override void ApplyMotion(CharacterViewModel characterViewModel)
		{
            var characterRigidbody = characterViewModel.GetComponent<Rigidbody>();

            if (HorizontalVelocity(characterRigidbody) < SpeedThreshold)
			{
				float axisValue = Input.GetAxis(AxisName);
                Vector3 forceVector = (RunningForce * axisValue) * Vector3.right;
				characterRigidbody.AddForce(forceVector, ForceMode.Impulse);
			}
		}

	}
}
