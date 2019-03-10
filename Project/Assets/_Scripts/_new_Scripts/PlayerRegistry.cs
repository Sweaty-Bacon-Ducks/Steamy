using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace Steamy.Player
{
	public class PlayerRegistry : NetworkBehaviour, IObjectRegistry<PlayerViewModel>
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

	}
}
