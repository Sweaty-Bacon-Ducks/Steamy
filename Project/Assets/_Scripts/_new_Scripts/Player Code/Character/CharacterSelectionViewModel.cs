using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectionViewModel : MonoBehaviour
{
	[SerializeField]
	private List<GameObject> availableCharacters;

	public string SceneCameraTag;
	private GameObject sceneCamera;
	public List<GameObject> AvailableCharacters
	{
		get { return availableCharacters; }
		set { availableCharacters = value; }
	}

	// Use this for initialization
	private void Start()
	{
		GameObject.FindGameObjectWithTag(SceneCameraTag).SetActive(false);
	}

	// Update is called once per frame
	private void Update()
	{

	}

	private void OnDisable()
	{
		GameObject.FindGameObjectWithTag(SceneCameraTag).SetActive(true);
	}
}
