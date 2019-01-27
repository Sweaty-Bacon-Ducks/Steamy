using System.ComponentModel;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.Networking;
using Steamy.Weapons;

namespace Steamy.Player
{
	public class CharacterViewModel : NetworkBehaviour
	{
		#region PublicInterface

		public string CharacterCameraTag;
		public string CharacterCameraName;
		public CharacterModel Model;
		public Text HealthView;
		public event Callback DeathCallback;

		public WeaponViewModel EquippedWeapon;

		public void Damage(double amount)
		{
			if (amount < 0)
				return;

			if (IsCharacterDead)
			{
				DeathCallback?.Invoke();
				return;
			}
			Model.Health.Value -= amount;
		}
		public void Heal(double amount)
		{
			if (amount < 0)
				return;

			if (Model.Health.Value + amount >= Model.Health.MaxValue)
			{
				Model.Health.Value = Model.Health.MaxValue;
				return;
			}
			Model.Health.Value += amount;
		}
		#endregion

		#region UnityMessages
		public override void OnStartLocalPlayer()
		{
			// Set the target transform on the camera
			var characterCamera = GameObject.FindGameObjectWithTag(CharacterCameraTag).GetComponent<CameraFollower>();
			characterCamera.Target = transform;

			Model.Health = Model.HealthDefaults?.LoadFromDefaults();

			Model.Health.PropertyChanged += OnHealthChanged;
			Model.Health.Value = Model.Health.MaxValue;
		}

		private void OnDisable()
		{
			if (!isLocalPlayer)
				return;

			Model.Health.PropertyChanged -= OnHealthChanged;
		}
		private void Update()
		{
			if (!isLocalPlayer)
				return;

			MoveCharacter();
		}
		#endregion

		#region PrivateInterface
		[SyncVar] private double m_CurrentHealth;

		private bool IsCharacterDead
		{
			get
			{
				return Model.Health.Value <= 0;
			}
		}
		private void MoveCharacter()
		{
			if (Model.MotionModes == null)
				return;

			foreach (var mode in Model.MotionModes)
			{
				mode.ApplyMotion(this);
			}
		}
		private void OnHealthChanged(object sender, PropertyChangedEventArgs e)
		{
			m_CurrentHealth = Model.Health.Value;
			if (HealthView)
			{
				HealthView.text = Model.Health.Value.ToString();
			}
		}
		#endregion
	}
}
