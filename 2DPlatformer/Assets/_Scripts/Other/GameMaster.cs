using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using CustomBehaviour;
/// <summary>
/// The GameMaster class is responsible for handling all events which are independent from the player
/// </summary>
public class GameMaster : SingletonBehaviour<GameMaster>
{
    private const string PLAYER_ID_PREFIX = "Player ";

    [SerializeField]
    private static Dictionary<string, Player> players = new Dictionary<string, Player>();

    [SerializeField]
    private GameObject NetManagerObject;


    void Awake()
    {
        InstantiateNetMenager();
    }

    public static void RegisterPlayer(string _netID, Player _player)
    {
        string _playerID = PLAYER_ID_PREFIX + _netID;
        players.Add(_playerID, _player);
        _player.transform.name = _playerID;
    }
    public static Player GetPlayer(string _playerID)
    {
        return players[_playerID];
    }
    public static void UnRegisterPlayer(string _playerID)
    {
        players.Remove(_playerID);
    }

    void InstantiateNetMenager()
    {
        if (NetworkManager.singleton == null)
        {
            Instantiate(NetManagerObject, Vector3.zero, Quaternion.identity);
        }
        else
        {
            Destroy(NetworkManager.singleton.gameObject);
            NetworkManager.singleton = null;
            Instantiate(NetManagerObject, Vector3.zero, Quaternion.identity);
        }
    }
}
