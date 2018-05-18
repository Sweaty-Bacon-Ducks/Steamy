using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// Odpowiada za wyłączenie odpowiednich komponentów, w każdej instancji gracza.
/// </summary>
[RequireComponent(typeof(Player))]
public class PlayerSetup : NetworkBehaviour
{
    private const string REMOTE_LAYER_MASK = "RemotePlayer";
    /// <summary>
    /// Lista komponentów, którą należy wypełnić w inspektorze
    /// </summary>
    [SerializeField]
    private List<Behaviour> componentsToDisable;

    void Start()
    {
        if (!isLocalPlayer)
        {
            DisableComponents();
            AssignRemoteLayer();
        }

        GetComponent<Player>().Setup();
    }

    public void AssignRemoteLayer()
    {
        gameObject.layer = LayerMask.NameToLayer(REMOTE_LAYER_MASK);
    }

    public override void OnStartClient()
    {
        string _netID = GetComponent<NetworkIdentity>().netId.ToString();
        Player _player = GetComponent<Player>();
        GameMaster.RegisterPlayer(_netID, _player);
    }

    private void OnDestroy()
    {
        Debug.Log("Unregistered " + transform.name);
        GameMaster.UnRegisterPlayer(transform.name);
    }
    void DisableComponents()
    {
        foreach (Behaviour behaviour in componentsToDisable)
        {
            if (behaviour != null)
            {
                behaviour.enabled = false;
            }
            else
            {
                Debug.LogError("Behaviour: " + behaviour.ToString() + " was null");
            }
        }
    }
}
