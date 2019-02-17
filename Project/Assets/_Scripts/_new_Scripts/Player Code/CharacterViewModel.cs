using System.ComponentModel;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using Steamy.Weapons;
using System;

namespace Steamy.Player
{
    public class CharacterViewModel : NetworkBehaviour, IDamagable
    {
        #region PublicInterface

        public CharacterModel Model;
        public WeaponViewModel EquippedWeapon;

        public event Callback DeathCallback;

        public void Damage(double amount)
        {
            Model.Health.Value -= Math.Max(amount, 0);

            if (IsCharacterDead)
            {
                DeathCallback?.Invoke();
            }
        }

        public void Heal(double amount)
        {
            Model.Health.Value += Mathf.Clamp(value: (float)amount,
                                              min: 0,
                                              max: (float)Model.Health.MaxValue);
        }
        #endregion

        #region UnityMessages
        private void OnDisable()
        {
            Model.Health.PropertyChanged -= OnHealthChanged;
        }

        public override void OnStartLocalPlayer()
        {
            if (!isLocalPlayer)
                return;

            // Set the target transform on the camera
            var characterCamera = GameObject.FindGameObjectWithTag(CharacterCameraTag).GetComponent<CameraFollower>();
            characterCamera.Target = transform;

            Model.Health = Model.HealthDefaults?.LoadFromDefaults();

            Model.Health.PropertyChanged += OnHealthChanged;
            Model.Health.Value = Model.Health.MaxValue;
        }

        private void Update()
        {
            if (!isLocalPlayer)
                return; 
              
            MoveCharacter();
        }
        #endregion

        #region PrivateInterface

        [SerializeField]
        private Text healthView;

        [SerializeField]
        public string CharacterCameraTag;

        [SerializeField]
        public string CharacterCameraName;

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
            if (healthView)
            {
                healthView.text = Model.Health.Value.ToString();
            }
        }
        #endregion
    }
}
