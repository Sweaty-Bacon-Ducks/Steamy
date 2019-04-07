using System.Collections.Generic;
using UnityEngine;

namespace Steamy.Player
{
    /// <summary>
    /// Holds information about all the players connected to the game.
    /// </summary>
	public class PlayerRegistry : MonoBehaviour, IObjectRegistry<PlayerViewModel>
	{
		private Dictionary<string, PlayerViewModel> playerRegistry;


		public void Add(string netId, PlayerViewModel player)
		{
			playerRegistry[netId] = player;
		}

		public PlayerViewModel Find(string netId)
		{
			if (playerRegistry.ContainsKey(netId))
			{
				return playerRegistry[netId];
			}
			return null;
		}

		public PlayerViewModel Remove(string netId)
		{
			var player = Find(netId);
			if (player)
			{
				playerRegistry.Remove(netId);
			}
			return player;
		}

        private void Awake()
        {
            playerRegistry = new Dictionary<string, PlayerViewModel>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                LogPlayers();
            }
        }

        public void LogPlayers()
        {
            foreach (KeyValuePair<string, PlayerViewModel> player in playerRegistry)
            {
                Debug.Log(player.Key);
            }
        }
    }
}
