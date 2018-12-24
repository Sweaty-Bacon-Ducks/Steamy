using System;
using System.IO;

using UnityEngine;

namespace Steamy.Player.MotionModes
{
	[Serializable]
    public abstract class MotionMode: ScriptableObject
	{
		public string Name;

        public abstract void ApplyMotion(CharacterViewModel characterViewModel);
	}
}
