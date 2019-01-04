using UnityEngine;

namespace Steamy
{
	public interface ICameraInteractor
	{
		void Interact(Camera camera);
	}

	public abstract class CameraInteractor : ScriptableObject, ICameraInteractor
	{
		public abstract void Interact(Camera camera);
	}
}

