using Steamy.Player;
using UnityEngine;
using UnityEngine.Networking;

//TODO: There's no handling of clients disconnecting from the server, cause I dont know the function :( (Simple NetworkIdentity.isValid would be great)

public class ClientsData : NetworkBehaviour
{
    public PlayersInfo PlayersInfo;

    public override void OnStartLocalPlayer()
    {
        if (GetComponent<NetworkIdentity>().isServer)
        {
            PlayersInfo.AddPlayer(GetComponent<NetworkIdentity>().netId, this.gameObject);
            CmdSendNameToAll(GetComponent<NetworkIdentity>().netId, "DziubDziub" + Random.Range(0, 10000)); // TODO: Odpalic skrypt, kiedy gracz wybierze nick/zaloguje sie
        }
        else
        {
            CmdRequestAllClients();
            CmdRequestClientsNames();
            CmdSendClientToAll(GetComponent<NetworkIdentity>().netId, this.gameObject);
            CmdSendNameToAll(GetComponent<NetworkIdentity>().netId, "DziubDziub" + Random.Range(0, 10000)); // TODO: Odpalic skrypt, kiedy gracz wybierze nick/zaloguje sie
        }
    }

    #region Sending Clients info

    [ClientRpc]
    private void RpcShareClient(NetworkInstanceId id, GameObject gameObject)
    {
        PlayersInfo.AddPlayer(id, gameObject);
    }

    [Command]
    private void CmdRequestAllClients()
    {
        foreach (PlayerInfo playerInfo in PlayersInfo)
        {
            RpcShareClient(playerInfo.ID, playerInfo.GameObject);
        }
    }

    [Command]
    private void CmdSendClientToAll(NetworkInstanceId id, GameObject gameObject)
    {
        PlayersInfo.AddPlayer(id, gameObject);
        RpcShareClient(id, gameObject);
    }

    #endregion

    #region Sending Clients names

    [ClientRpc] // Sending from server to clients
    private void RpcSendNameToClients(NetworkInstanceId id, string name)
    {
        PlayersInfo.FindByID(id).GameObject.name = name;
        PlayersInfo.FindByID(id).GameObject.GetComponent<CharacterViewModel>().Model.Name = name;
    }

    [Command]
    private void CmdRequestClientsNames()
    {
        foreach (PlayerInfo playerInfo in PlayersInfo)
        {
            RpcSendNameToClients(playerInfo.ID, playerInfo.GameObject.name);
        }
    }

    [Command] // Sending from clients to server
    private void CmdSendNameToAll(NetworkInstanceId id, string nameToSend)
    {
        PlayersInfo.FindByID(id).GameObject.name = nameToSend;
        RpcSendNameToClients(id, nameToSend);
    }

    #endregion
}