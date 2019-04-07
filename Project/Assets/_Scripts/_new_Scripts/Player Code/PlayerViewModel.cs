using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace Steamy.Player
{
    public class PlayerViewModel : NetworkBehaviour
    {
        [SerializeField]
        private PlayerRegistry playerRegistry;
        private NetworkIdentity networkIdentity;

        PlayerModel model;

        public LeaderBoard LeaderBoard;

        private void Awake()
        {
            model = new PlayerModel();

            networkIdentity = GetComponent<NetworkIdentity>();
            playerRegistry = FindObjectOfType<PlayerRegistry>();
            LeaderBoard = FindObjectOfType<LeaderBoard>();
        }

        private void Start()
        {
            playerRegistry.Add(networkIdentity.netId.ToString(), this);
            gameObject.name = networkIdentity.netId.ToString();

            LeaderBoard.AddPlayer(gameObject.name);
        }

        private void OnDestroy()
        {
            playerRegistry.Remove(networkIdentity.netId.ToString());
        }
    }
}
