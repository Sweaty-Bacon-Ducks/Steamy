using Steamy.Player;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Networking;

namespace Steamy.Networking
{
	[RequireComponent(typeof(CharacterViewModel))]
	public class CharacterDataSynchronizer : NetworkBehaviour, IDataSynchronizer
	{
		public void UpdateData()
		{
			syncedData = new CharacterNetworkData
			{
				Health = character.Model.Health.Value
			};

            if (!isServer)
            {
                CmdSynchronize(syncedData);
            }
		}

        [SyncVar]
		private CharacterNetworkData syncedData;

		private CharacterViewModel character;

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

        public override void OnStartLocalPlayer()
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
