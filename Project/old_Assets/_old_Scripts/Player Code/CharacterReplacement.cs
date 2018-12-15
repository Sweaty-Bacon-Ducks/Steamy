using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CharacterReplacement : NetworkBehaviour
{
    [SyncVar]
    public int SelectedAvatar = 0;

    [Command]
    private void Cmd_ReplaceCharacter(int selectedAvatar)
    {   
        //This line spawns the prefab just like any signle player game on the server.
        GameObject newPlayer = Instantiate(GameMaster.Instance.PlayerPrefabs[selectedAvatar], transform.position, transform.rotation);
        //Then this just tells all the clients to spawn the same object.
        NetworkServer.Spawn(newPlayer);
        //Then we try to replace it. And if it succeeded.
        if (NetworkServer.ReplacePlayerForConnection(connectionToClient, newPlayer, playerControllerId))
        {
            //We destroy the current player across all instances
            NetworkServer.Destroy(gameObject);
        }
    }
    [Client]
    public void ReplaceCharacter()
    {
        Cmd_ReplaceCharacter(SelectedAvatar);
    }
    [Client]
    public void SelectSteamBlow()
    {
        SelectedAvatar = 0;
        Debug.Log("Selected Steam Blow");
    }
    [Client]
    public void SelectUmbrellaGirl()
    {
        SelectedAvatar = 1;
        Debug.Log("Selected Umbrella Girl");
    }
}
