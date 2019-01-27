using UnityEngine;

namespace Steamy
{
	public class GlobalTransformFollower : MonoBehaviour, ITransformFollower
	{
		public float FollowSpeed;
		public bool FollowRotation;

			
		[SerializeField]
		private Transform m_Transform;

		public Vector3 PositionOffset;
		public Vector3 RotationOffset;

		

		public Transform Target
		{
			get { return m_Transform; }
			set { m_Transform = value; }
		}

		public void Follow()
		{
			var currentPosition = transform.position;
			var targetPosition = ApplyOffsetToTargetPosition(Target.position,
															 PositionOffset);

			transform.position = Vector3.Lerp(currentPosition,
												   targetPosition,
												   FollowSpeed * Time.deltaTime);

			if (FollowRotation)
			{
				var currentRotation = transform.localRotation;
				var targetRotation = ApplyOffsetToTargetRotation(Target.rotation,
																 Quaternion.Euler(RotationOffset));

				transform.localRotation = Quaternion.Slerp(currentRotation,
														   targetRotation,
														   FollowSpeed * Time.deltaTime);
			}
		}

		private Vector3 ApplyOffsetToTargetPosition(Vector3 TargetPosition,
													Vector3 Offset)
		{
			return TargetPosition + Offset;
		}

		private Quaternion ApplyOffsetToTargetRotation(Quaternion TargetRotation,
													   Quaternion Offset)
		{
			return TargetRotation * Offset;
		}

		private void LateUpdate()
		{
			if (Target)
				Follow();
		}
	}
}

