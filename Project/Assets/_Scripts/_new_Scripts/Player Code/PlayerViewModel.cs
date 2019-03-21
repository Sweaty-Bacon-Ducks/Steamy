
using UnityEngine;
using UnityEngine.Networking;

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
}
