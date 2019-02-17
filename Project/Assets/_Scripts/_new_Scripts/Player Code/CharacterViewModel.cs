using System;
using System.ComponentModel;
using Steamy.Editor;
using Steamy.Weapons;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

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
            var characterCamera = GameObject.FindGameObjectWithTag(characterCameraTag).GetComponent<CameraFollower>();
            characterCamera.Target = transform;

            Model.Health = Model.HealthDefaults?.LoadFromDefaults();
            OnHealthChanged(this, null);
            Model.Health.PropertyChanged += OnHealthChanged;
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

        [SerializeField]
        private Text healthView;

        [SerializeField, Tag]
        private string characterCameraTag;

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
