using System;
using System.Linq;
using System.Collections.Generic;

using UnityEngine;

using Steamy.Player.MotionModes;

namespace Steamy.Player
{
	public class CharacterViewModel : MonoBehaviour
	{
		[HideInInspector]
		public CharacterModel Model;

		public List<TextAsset> MotionModeDefinitionPaths;
		public List<MotionMode> MotionModes;

		private void Awake()
		{
			Model.ViewModel = this;
		}

		private void ApplyMotion()
		{
			foreach (var mode in MotionModes)
			{
				mode.ApplyMotion();
			}
		}

		private void FixedUpdate()
		{
			ApplyMotion();
		}
	}
}
