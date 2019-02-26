using System;
using System.ComponentModel;
using Steamy.Editor;
using Steamy.Weapons;
using Steamy.Networking;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace Steamy.Player
{
    public class CharacterViewModel : NetworkBehaviour, IDamagable
    {
		#region PublicInterface
		public CharacterDataSynchronizer NetworkData;
		public event Callback HealthChanged;
        public event Callback DeathCallback;

		public CharacterModel Model;
        public WeaponViewModel EquippedWeapon;

        [SerializeField]
        private Text healthView;
        [SerializeField, Tag]
        private string characterCameraTag;
        private CharacterDataSynchronizer characterDataSynchronizer;

		public void Damage(double amount)
		{
			if (IsCharacterDead)
				DeathCallback?.Invoke();
			else
			{
				var newValue = Math.Max(amount, 0.0);
				NetworkData.Health -= newValue;
				HealthChanged?.Invoke();
			}
		}

        public void Heal(double amount)
        {
            NetworkData.Health += Mathf.Clamp(value: (float)amount,
                                              min: 0,
                                              max: (float)Model.Health.MaxValue);
			HealthChanged();
        }
        #endregion

        #region UnityMessages
        private void OnDisable()
        {
            HealthChanged -= OnHealthChanged;
        }

        public override void OnStartLocalPlayer()
        {
            // Set the target transform on the camera
            var characterCamera = GameObject.FindGameObjectWithTag(characterCameraTag).GetComponent<CameraFollower>();
            characterCamera.Target = transform;

			Model.Health = Model.HealthDefaults?.LoadFromDefaults();

			HealthChanged += OnHealthChanged;
			HealthChanged();
		}

		private void Awake()
		{
			Model.Health = Model.HealthDefaults?.LoadFromDefaults();

			NetworkData = GetComponent<CharacterDataSynchronizer>();
			NetworkData.Health = Model.Health.MaxValue;

			//HealthChanged += OnHealthChanged;
			//HealthChanged();
		}

		private void Update()
        {
            if (!isLocalPlayer)
                return;

            if (Input.GetKeyDown(KeyCode.K))
            {
                Damage(5f);
            }

            MoveCharacter();
        }
        #endregion

        #region PrivateInterface

        private bool IsCharacterDead
        {
            get
            {
                return NetworkData.Health <= 0;
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

        private void OnHealthChanged()
        {
            if (!isLocalPlayer)
                return;

            Debug.Log($"Health value: {NetworkData.Health}");

            if (healthView)
            {
                healthView.text = NetworkData.Health.ToString();
            }
        }
        #endregion
    }
}

