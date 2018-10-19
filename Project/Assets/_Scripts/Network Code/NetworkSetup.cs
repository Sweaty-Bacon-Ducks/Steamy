using UnityEngine;
using UnityEngine.Networking;
public class NetworkSetup : NetworkBehaviour
{
    private GameObject lobbyCam;
    private void Awake()
    {
        if (!isLocalPlayer)
        {
            lobbyCam = GameObject.Find("LobbyCam");
        }
    }
    void Start()
    {
        if (isLocalPlayer)
        {
            lobbyCam = Camera.main.gameObject;
            if (lobbyCam != null)
            {
                lobbyCam.SetActive(false);
            }
        }
    }
    void OnDisable()
    {
        if (lobbyCam!= null)
        {
            lobbyCam.SetActive(true);
        }    
    }
}
