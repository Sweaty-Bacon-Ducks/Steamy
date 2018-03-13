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
        GameObject hostButton = GameObject.Find("ButtonHostuj");
        hostButton.GetComponent<Button>().onClick.RemoveAllListeners();
        hostButton.GetComponent<Button>().onClick.AddListener(HostGame);

        GameObject joinButton = GameObject.Find("ButtonPołącz");
        joinButton.GetComponent<Button>().onClick.RemoveAllListeners();
        joinButton.GetComponent<Button>().onClick.AddListener(JoinGame);
    }
    private void SetupOtherScene()
    {
        GameObject inGameMenu = GameObject.Find("ButtonDisconnect");
        inGameMenu.GetComponent<Button>().onClick.RemoveAllListeners();
        inGameMenu.GetComponent<Button>().onClick.AddListener(singleton.StopClient);
        inGameMenu.transform.root.gameObject.SetActive(false);
    }
}
