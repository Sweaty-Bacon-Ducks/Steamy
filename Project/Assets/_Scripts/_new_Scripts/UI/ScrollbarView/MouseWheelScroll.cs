using UnityEngine;
using UnityEngine.UI;

public class MouseWheelScroll : MonoBehaviour
{
	[Range(min: -1, max: 1, order = 0)]
	public float Smoothing;

	private Scrollbar targetScrollbar;

	private void Awake()
	{
		targetScrollbar = GetComponent<Scrollbar>();
	}

	private void Update()
	{
		var mouseWheel = Input.mouseScrollDelta;
		targetScrollbar.value += mouseWheel.y * Smoothing;
	}
}
