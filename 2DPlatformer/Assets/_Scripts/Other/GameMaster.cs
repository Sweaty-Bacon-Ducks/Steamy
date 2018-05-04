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
    public GameObject NetManagerObject;
    public GameObject EventManagerObject;
    void Awake()
    {
        InstantiateNetMenager();
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
