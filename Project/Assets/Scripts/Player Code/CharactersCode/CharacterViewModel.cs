using System;
using System.Collections.Generic;

using UnityEngine;

using Steamy.Player.MotionModes;

namespace Steamy.Player
{
	public class CharacterViewModel : MonoBehaviour
	{
		public CharacterModel Model;
        public CharacterParameters Parameters;

        private void Awake()
        {
            Model.ViewModel = this;
        }

        private void ApplyMotion()
        {
            foreach (var mode in Parameters.MotionModesSet)
            {
                mode.ApplyMotion(this);
            }
        }

        private void FixedUpdate()
		{
			ApplyMotion();
		}
	}
}
