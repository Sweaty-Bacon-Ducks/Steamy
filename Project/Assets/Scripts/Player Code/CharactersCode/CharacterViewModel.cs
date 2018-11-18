using System;
using System.Collections.Generic;

using UnityEngine;

using Steamy.Player.MotionModes;

namespace Steamy.Player
{
	public class CharacterViewModel : MonoBehaviour
	{
		public CharacterModel Model;

		public HashSet<MotionMode> MotionModes;

        private void Awake()
        {
			MotionModes = new HashSet<MotionMode>
			{
				new HorizontalRunMode(this),
				new JumpMode(this)
			};
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
