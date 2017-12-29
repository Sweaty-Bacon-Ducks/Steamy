using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomBehaviour;
/// <summary>
/// The GameMaster class is responsible for handling all events which are independent from the player
/// </summary>
public class GameMaster : SingletonBehaviour
{
    #region Weapons
    public Transform WeaponHolder;
    /// <summary>
    /// List of all gameObjects under Player.Weapons in the hierarchy
    /// </summary>
    public List<GameObject> AllWeapons;
    /// <summary>
    /// Initializes the AllWeapons list with all gameObjects which represents weapons
    /// </summary>
    /// <returns>
    /// Return the list of all weapons
    /// </returns>
    public List<GameObject> Initialize(Transform player)
    {
        foreach (Transform tr in player)
        {
            if (tr != player.root && !AllWeapons.Contains(tr.gameObject))
            {
                AllWeapons.Add(tr.gameObject);
                Debug.Log("The object " + tr.name + " was loaded!");
            }
        }
        return AllWeapons;
    }
    #endregion

    private void OnEnable()
    {
        Initialize(WeaponHolder);
    }
}
