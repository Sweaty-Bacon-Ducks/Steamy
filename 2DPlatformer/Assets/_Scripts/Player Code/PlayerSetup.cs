using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// Odpowiada za wyłączenie odpowiednich komponentów, w każdej instancji gracza.
/// </summary>
[RequireComponent(typeof(Player))]
public class PlayerSetup : NetworkBehaviour
{
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
        }
    }

    public override void OnStartClient()
    {
        string _netID = GetComponent<NetworkIdentity>().netId.ToString();
        Player _player = GetComponent<Player>();
        GameMaster.RegisterPlayer(_netID, _player);
    }
    private void OnDisable()
    {
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
