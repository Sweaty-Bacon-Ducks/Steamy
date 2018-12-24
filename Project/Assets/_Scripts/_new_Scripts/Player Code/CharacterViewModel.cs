using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

namespace Steamy.Player
{
    public class CharacterViewModel : MonoBehaviour
    {
        #region PublicInterface

        public CharacterModel Model;
        public Text HealthView;
        public event Callback DeathCallback;

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
        private void Awake()
        {
            Model.Health = Model.HealthDefaults.Create();

            Model.Health.PropertyChanged += OnHealthChanged;
            Model.Health.Value = Model.Health.MaxValue;
        }
        private void OnDisable()
        {
            Model.Health.PropertyChanged -= OnHealthChanged;
        }
        private void Update()
        {
            MoveCharacter();
        }
        #endregion

        #region PrivateInterface
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
            if (HealthView)
            {
                HealthView.text = Model.Health.Value.ToString();
            }
        }
        #endregion
    }
}
