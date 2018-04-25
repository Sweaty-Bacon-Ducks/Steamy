using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// Odpowiada za wyłączenie odpowiednich komponentów, w każdej instancji gracza.
/// </summary>
public class PlayerSetup : NetworkBehaviour
{
    /// <summary>
    /// Lista komponentów, którą należy wypełnić w inspektorze
    /// </summary>
    [SerializeField]
    List<Behaviour> componentsToDisable;

    void Start()
    {
        if (!isLocalPlayer)
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
}
