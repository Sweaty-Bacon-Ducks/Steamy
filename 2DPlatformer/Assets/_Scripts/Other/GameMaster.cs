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
    public GameObject NetManager;
    void Awake()
    {
        if (NetworkManager.singleton == null)
        {
            Instantiate(NetManager, Vector3.zero, Quaternion.identity);
        }
        else
        {
            Destroy(NetworkManager.singleton.gameObject);
            NetworkManager.singleton = null;
            Instantiate(NetManager, Vector3.zero, Quaternion.identity);
        }
        //DontDestroyOnLoad(gameObject);
    }
    public void LoadMainMenuScene()
    {
        SceneManager.LoadScene("MenuTest");
    }

}
