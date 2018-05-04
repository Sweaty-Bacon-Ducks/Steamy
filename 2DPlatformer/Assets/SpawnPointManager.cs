using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using CustomBehaviour;

public class SpawnPointManager : SingletonBehaviour<SpawnPointManager>
{
    [HideInInspector]
    public List<GameObject> SpawnPoints;

    void Awake()
    {
        _instance = this;
        //Zainicjalizuj listę spawnów na scenie
        SpawnPoints = new List<GameObject>();
        foreach (Transform spawn in transform)
        {
            if (spawn != transform)
            {
                if (spawn.GetComponent<NetworkStartPosition>())
                {
                    SpawnPoints.Add(spawn.gameObject);
                    Debug.Log(spawn.name);
                }
            }
        }
        if (SpawnPoints.Count == 0)
        {
            Debug.LogError("No spawn points on the scene");
        }
    }
}
