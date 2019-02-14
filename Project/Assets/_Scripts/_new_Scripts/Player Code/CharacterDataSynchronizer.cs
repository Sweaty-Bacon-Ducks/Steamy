using System.ComponentModel;

using UnityEngine;
using UnityEngine.Networking;

using Steamy.Player;

namespace Steamy.Networking
{
    [RequireComponent(typeof(CharacterViewModel))]
    public class CharacterDataSynchronizer : NetworkBehaviour, IDataSynchronizer
    {
        [SyncVar]
        private CharacterNetworkData syncedData;

        private CharacterViewModel character;

        public void UpdateData()
        {
            syncedData = new CharacterNetworkData
            {
                Health = character.Model.Health.Value
            };

            CmdSynchronize(syncedData);
        }

        [Command]
        private void CmdSynchronize(CharacterNetworkData newData)
        {
            syncedData = newData;
            RpcSynchronize(newData);
        }

        [ClientRpc]
        private void RpcSynchronize(CharacterNetworkData newData)
        {
            syncedData = newData;
        }

        private void Awake()
        {
            character = GetComponent<CharacterViewModel>();
            character.Model.Health.PropertyChanged += OnHealthChanged;

            syncedData = new CharacterNetworkData
            {
                Health = character.Model.Health.MaxValue
            };

            UpdateData();
        }

        private void OnHealthChanged(object sender, PropertyChangedEventArgs e)
        {
            UpdateData();
        }

    }
}
