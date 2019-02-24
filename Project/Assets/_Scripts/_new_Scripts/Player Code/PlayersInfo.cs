using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[CreateAssetMenu]
public class PlayersInfo : ScriptableObject, IEnumerable<PlayerInfo>
{
    public HashSet<PlayerInfo> Infos = new HashSet<PlayerInfo>();

    public void AddPlayer(NetworkInstanceId id, GameObject gameObject)
    {
        PlayerInfo player = new PlayerInfo(id, gameObject);

        Infos.Add(player);
    }

    //TODO: Find appropriate way of finding an element
    public PlayerInfo FindByID(NetworkInstanceId id)
    {
        foreach (PlayerInfo playerInfo in Infos)
        {
            if (playerInfo.ID == id)
                return playerInfo;
        }
        return null;
    }

    public IEnumerator<PlayerInfo> GetEnumerator()
    {
        return Infos.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return Infos.GetEnumerator();
    }
}

public class PlayerInfo
{
    public NetworkInstanceId ID { get; private set; }
    public GameObject GameObject;


    int kills;
    int deaths;

    public PlayerInfo(NetworkInstanceId id, GameObject gameObject)
    {
        this.ID = id;
        this.GameObject = gameObject;
    }

    public override int GetHashCode()
    {
        return this.ID.GetHashCode();
    }
    public override bool Equals(object obj)
    {
        var other = obj as PlayerInfo;

        return this.ID.Equals(other.ID);
    }
}