using UnityEngine;

namespace Steamy
{
	public interface ICameraFollower
	{
		void Follow(Transform target);
	}

	[RequireComponent(typeof(Camera))]
	public class CameraFollow : MonoBehaviour, ICameraFollower
	{
		private Camera m_Camera;

		public Transform Target;

		public Vector3 PositionOffset;
		public Vector3 RotationOffset;
		public float MovementSpeed = 8f;
		public float MouseRange = 5f;

		private void Start()
		{
			m_Camera = GetComponent<Camera>();

			//transform.rotation *= Quaternion.Euler(RotationOffset); // Add the rotation offset. YES, ADD!
		}

		private void LateUpdate()
		{
			if (Target != null)
				Follow(Target);
		}

		public void Follow(Transform target)
		{
			var targetPosition = Target.position;
			var cursorPosition = m_Camera.ScreenToWorldPoint(new Vector3
			{
				x = Input.mousePosition.x,
				y = Input.mousePosition.y,
				z = MouseRange
			});

			var targetCameraPosition = GetTargetCameraPosition(cursorPosition, targetPosition);
			transform.localPosition = Vector3.Lerp(transform.position, targetCameraPosition, Time.deltaTime * MovementSpeed);
		}

		private Vector3 GetTargetCameraPosition(Vector3 start, Vector3 end)
		{
			return new Vector3
			{
				x = (start.x + end.x) / 2 + PositionOffset.x,
				y = (start.y + end.y) / 2 + PositionOffset.y,
				z = end.z + PositionOffset.z
			};
		}
	}
}

