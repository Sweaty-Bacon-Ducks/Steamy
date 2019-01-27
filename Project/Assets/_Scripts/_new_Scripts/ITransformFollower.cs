using UnityEngine;

public interface ITransformFollower
{
	Transform Target { get; set; }
	void Follow();
}
