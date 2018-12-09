using System;
using UnityEngine;

namespace Steamy.Player.MotionModes
{
	public interface ISpeedScaler
	{
		float ScaleUp(float value);
		float ScaleDown(float value);
	}

	public class LinearFixedDeltaTimeScaler : ISpeedScaler
	{
		private readonly float speedUpConstant;
		private readonly float slowDownConstant;

		public LinearFixedDeltaTimeScaler(float speedUpConstant, float slowDownConstant)
		{
			this.speedUpConstant = speedUpConstant;
			this.slowDownConstant = slowDownConstant;
		}

		public float ScaleDown(float value)
		{
			return value - Time.fixedDeltaTime * slowDownConstant;
		}

		public float ScaleUp(float value)
		{
			return value + Time.fixedDeltaTime * speedUpConstant;
		}
	}

	public abstract class SpeedScalerDecorator : ISpeedScaler
	{
		public ISpeedScaler SpeedScaler;

		public SpeedScalerDecorator(ISpeedScaler SpeedScaler)
		{
			this.SpeedScaler = SpeedScaler;
		}

		public abstract float ScaleDown(float value);
		public abstract float ScaleUp(float value);
	}

	public class Clamped01LinearScaler : SpeedScalerDecorator
	{
		public Clamped01LinearScaler(ISpeedScaler SpeedScaler) : base(SpeedScaler) { }

		public override float ScaleDown(float value)
		{
			return Mathf.Clamp01(SpeedScaler.ScaleDown(value));
		}

		public override float ScaleUp(float value)
		{
			return Mathf.Clamp01(SpeedScaler.ScaleUp(value));
		}
	}

	[CreateAssetMenu(menuName = "MotionModes/AnimatedRunMode")]
	public class AnimatedRunMode : MotionMode
	{
		public string AxisName;
		public float AxisDeadzone;

		public float Acceleration;
		public float Deceleration;
		public ForceMode ForceMode;
		public float SpeedThreshold;

		public string AnimationSpeedVariable;

		public ISpeedScaler SpeedScaler;

		private const float MAX_AXIS_VALUE = 1f;

		private void OnEnable()
		{
			SpeedScaler = new Clamped01LinearScaler(
					new LinearFixedDeltaTimeScaler(Acceleration, Deceleration)
				);
		}

		private float HorizontalVelocity(Rigidbody characterRigidbody)
		{
			return Mathf.Abs(characterRigidbody.velocity.x);
		}

		private bool InputInRange(float playerInput)
		{
			return Mathf.Abs(playerInput - MAX_AXIS_VALUE) < AxisDeadzone;
		}

		private bool SpeedInRange(float playerSpeed)
		{
			return Mathf.Abs(playerSpeed) < SpeedThreshold;
		}

		public override void ApplyMotion(CharacterViewModel characterViewModel)
		{
			var characterRigidbody = characterViewModel.GetComponent<Rigidbody>();

			var animator = characterViewModel.GetComponent<Animator>();
			var currentSpeed = animator.GetFloat(AnimationSpeedVariable);
			var playerInput = Input.GetAxis(AxisName);

			float newSpeed = 0;
			if (InputInRange(playerInput))
			{
				newSpeed = SpeedScaler.ScaleUp(currentSpeed);
				animator.SetFloat(AnimationSpeedVariable, newSpeed);
			}
			else
			{
				newSpeed = SpeedScaler.ScaleDown(currentSpeed);
				animator.SetFloat(AnimationSpeedVariable, newSpeed);
			}
			currentSpeed = newSpeed;

			var playerSpeed = characterRigidbody.velocity.x;
			if (SpeedInRange(playerSpeed))
			{
				//characterRigidbody.AddForce(currentSpeed * Vector2.right, ForceMode);
                characterRigidbody.velocity = new Vector3(currentSpeed * 5, 0, 0);
            }

		}
	}
}

