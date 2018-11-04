using System;

using UnityEngine;

using Steamy.Player.MotionModes;

namespace Steamy.Player
{
	public class CharacterViewModel : MonoBehaviour
	{
		[SerializeField]
		public CharacterModel Model;

		public string XmlFilePath;

		private void Awake()
		{
			Model = CharacterModel.ReadFromXml(XmlFilePath, new Type[] { typeof(MotionMode) });
			Model.ViewModel = this;
		}


		private void Update()
		{
			// Move the character based on player input
			Model.DoMotion();
		}
	}
}
