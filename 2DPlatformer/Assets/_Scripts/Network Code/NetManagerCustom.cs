using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;
using System;

//Wybieranie mapy jest kolejną rzeczą do zrobienia ostatnią do ukończenia menu głównego
public class NetManagerCustom : NetworkManager
{
    [SerializeField] private TMP_InputField IPAddress;
    [SerializeField] private TMP_InputField HostPort;
    [SerializeField] private TMP_InputField ConnectPort;

    public void HostGame()
    {
        SetPort(HostPort.text);
        singleton.StartHost();
    }
    public void JoinGame()
    {
        SetIPAdress(IPAddress.text);
        SetPort(ConnectPort.text);
        singleton.StartClient();
    }
    public void SetPort(string port)
    {
        singleton.networkPort = Convert.ToInt32(port);
    }
    public void SetIPAdress(string IPAddress)
    {
        singleton.networkAddress = IPAddress;
    }
    void OnLevelWasLoaded(int level)
    {
        if (level == 0) //Menu główne
        {
            SetupMenuScene();
        }
        else
        {
            SetupOtherScene();
        }
    }
    private void SetupMenuScene()
    {
        GameObject.Find("ButtonHostuj").GetComponent<Button>().onClick.RemoveAllListeners();
        GameObject.Find("ButtonHostuj").GetComponent<Button>().onClick.AddListener(HostGame);

        GameObject.Find("ButtonPołącz").GetComponent<Button>().onClick.RemoveAllListeners();
        GameObject.Find("ButtonPołącz").GetComponent<Button>().onClick.AddListener(JoinGame);
    }
    private void SetupOtherScene()
    {
        GameObject.Find("ButtonDisconnect").GetComponent<Button>().onClick.RemoveAllListeners();
        GameObject.Find("ButtonDisconnect").GetComponent<Button>().onClick.AddListener(singleton.StopClient);
    }
}
