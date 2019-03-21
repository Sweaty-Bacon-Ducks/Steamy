
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
				return !(GameObject.
					Find(NetworkManagerTag).
					GetComponent<NetworkManager>() == null);
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
				return null;
			}
		}

		private void Awake()
		{
			model.NetID = netId;
		}


	}
}

namespace Steamy.Player
{
    public class PlayerViewModel : NetworkBehaviour
    {
        [SerializeField]
        private PlayerRegistry playerRegistry;
        private NetworkIdentity networkIdentity;

        private void Awake()
        {
            networkIdentity = GetComponent<NetworkIdentity>();
            playerRegistry = FindObjectOfType<PlayerRegistry>();
        }

        private void Start()
        {
            playerRegistry.Add(networkIdentity.netId.ToString(), this);
        }
    }