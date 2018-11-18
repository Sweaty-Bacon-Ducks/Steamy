using System;

using UnityEngine;

namespace Steamy.Player.MotionModes
{
	[Serializable]
	public sealed class HorizontalRunMode : MotionMode
	{
		public string AxisName;
		public float RunningForce;
		public float SpeedThreshold;

		[NonSerialized]
		private Rigidbody characterRigidbody;

		public HorizontalRunMode() {	}
		public HorizontalRunMode(CharacterViewModel viewModel) : base(viewModel)
		{
			this.characterRigidbody = this.viewModel.GetComponent<Rigidbody>();
		}

		private float horizontalVelocity
		{
			get
			{
				return characterRigidbody.velocity.z;
			}
		}

		public override void ApplyMotion()
		{
			if (horizontalVelocity < SpeedThreshold)
			{
				float axisValue = Input.GetAxis(AxisName);
				Vector3 forceVector = (RunningForce * axisValue) * Vector3.forward;
				characterRigidbody.AddForce(forceVector, ForceMode.Impulse);
			}
		}

	}
}
