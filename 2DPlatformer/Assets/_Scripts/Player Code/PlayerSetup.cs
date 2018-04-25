using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerSetup : NetworkBehaviour
{
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
