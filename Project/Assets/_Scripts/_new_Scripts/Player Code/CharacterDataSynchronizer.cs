using Steamy.Player;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Networking;

namespace Steamy.Networking
{
	[RequireComponent(typeof(CharacterViewModel))]
	public class CharacterDataSynchronizer : NetworkBehaviour
	{
		[SerializeField, SyncVar]
		public CharacterNetworkData NetworkData;

		public double Health
		{
			get => NetworkData.Health;
			set => NetworkData.Health = value;
		}

	}
}
