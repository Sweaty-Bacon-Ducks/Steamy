
using UnityEngine;
using UnityEngine.Networking;

namespace Steamy.Player
{

	public class PlayerViewModel : NetworkBehaviour
	{
		public string NetworkManagerTag;

		[SerializeField]
		private PlayerModel model;

		private bool isNetworkManagerAvailable
		{
			get
			{
				GameObject networkManager;
				bool foundNetworkManager = false;
				if(networkManager = GameObject.FindGameObjectWithTag(NetworkManagerTag))
				{
					foundNetworkManager = networkManager.GetComponent<NetworkManager>() == null;
				}
				return foundNetworkManager;
			}
		}

		private string netId
		{
			get
			{
				if (isNetworkManagerAvailable)
				{
					return GetComponent<NetworkIdentity>().
										netId.
										Value.
										ToString();
				}
				return "";
			}
		}
		public override void OnStartClient()
		{
			if (isLocalPlayer)
			{

				model.NetID = netId;
			}
		}

	}
}
