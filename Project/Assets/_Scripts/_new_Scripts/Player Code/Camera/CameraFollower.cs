using UnityEngine;

namespace Steamy
{
	[RequireComponent(typeof(Camera))]
	public class CameraFollower : MonoBehaviour, ITransformFollower
	{
		private Camera m_Camera;

		[SerializeField]
		private Transform m_Target;

		public Transform Target
		{
			get { return m_Target; }
			set { m_Target = value; }
		}

		public Vector3 PositionOffset;
		public float MovementSpeed = 8f;
		public float MouseRange = 5f;

		private void Start()
		{
			m_Camera = GetComponent<Camera>();
		}

		private void LateUpdate()
		{
			if (Target != null)
				Follow();
		}

		public void Follow()
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

