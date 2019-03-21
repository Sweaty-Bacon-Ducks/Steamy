using System.Collections.Generic;
using UnityEngine;

public interface IObjectRegistry<T> where T : MonoBehaviour
{
	T Find(string netId);
	void Add(string netId, T player);
	T Remove(string netId);
}
