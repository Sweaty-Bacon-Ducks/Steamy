using System;

using UnityEngine;

using Steamy.Player.MotionModes;
using UnityEngine.UI;
using System.ComponentModel;

namespace Steamy.Player
{
	public class CharacterViewModel : MonoBehaviour
	{
		public CharacterModel Model;

        public Text HealthView;

		private void Awake()
		{
            Model.Health.PropertyChanged += OnHealthChanged;
            Model.Health.Value = Model.Health.MaxValue;
        }

        private void Update()
		{

            MoveCharacter();

            if (Input.GetKeyDown(KeyCode.K))
            {
                Model.Health.Value -= 1;
            }
		}

        private void MoveCharacter()
        {
            if (Model.MotionModes == null)
                return;

            foreach (var mode in Model.MotionModes)
            {
                mode.Do(this);
            }
        }

        private void OnHealthChanged(object sender, PropertyChangedEventArgs e)
        {
            HealthView.text = Model.Health.Value.ToString();
        }
    }
}
