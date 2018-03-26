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
        GameObject Menu = GameObject.Find("Menu");

        GameObject join = Menu.FindObject("Połącz");
        IPAddress = join.FindObject("IPAddress").GetComponent<TMP_InputField>();
        ConnectPort = join.FindObject("Port").GetComponent<TMP_InputField>();

        GameObject host = Menu.FindObject("Hostuj");
        HostPort = host.FindObject("Port").GetComponent<TMP_InputField>();

        GameObject joinButton = join.FindObject("ButtonPołącz");
        GameObject hostButton = host.FindObject("ButtonHostuj");

        hostButton.GetComponent<Button>().onClick.RemoveAllListeners();
        hostButton.GetComponent<Button>().onClick.AddListener(HostGame);

        
        joinButton.GetComponent<Button>().onClick.RemoveAllListeners();
        joinButton.GetComponent<Button>().onClick.AddListener(JoinGame);

    }
    private void SetupOtherScene()
    {
        GameObject disconnectButton = GameObject.Find("ButtonDisconnect");
        disconnectButton.GetComponent<Button>().onClick.RemoveAllListeners();
        disconnectButton.GetComponent<Button>().onClick.AddListener(singleton.StopClient);
    }
}
