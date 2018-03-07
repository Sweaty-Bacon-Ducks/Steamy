using UnityEngine;
using UnityEngine.Networking;
public class NetworkSetup : NetworkBehaviour
{
    [SerializeField]
    Camera networkCamera;

    void Start()
    {
        if (isLocalPlayer)
        {
            networkCamera = Camera.main;
            if (networkCamera != null)
            {
                networkCamera.gameObject.SetActive(false);
            }
        }
    }
    void OnDisable()
    {
        if (networkCamera!= null)
        {
            networkCamera.gameObject.SetActive(true);
        }    
    }
}
