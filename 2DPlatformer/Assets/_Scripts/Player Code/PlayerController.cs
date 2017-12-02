using System;
using System.Collections.Generic;
using UnityEngine;

public static class Constants
{
    /// <summary>
    /// List of all weapons under Player.Weapons in the hierarchy
    /// </summary>
    public static List<GameObject> AllWeapons;
    /// <summary>
    /// Initializes the AllWeapons list with all weapons 
    /// </summary>
    /// <returns>
    /// Return the list of all weapons
    /// </returns>
    public static List<GameObject> Initialize(Transform player)
    {
        foreach (Transform tr in player)
        {
            if (tr != player.root && !AllWeapons.Contains(tr.gameObject))
            {
                AllWeapons.Add(tr.gameObject);
            }
        }
        return AllWeapons;
    }
}

public class PlayerController : MonoBehaviour
{
#region Perks&Stats
//Tutaj będzie miejsce na implementację perków i statystyk (kiedyś na pewno to zrobimy)
#endregion

#region Equipment
    public int MaxSize;
    public List<GameObject> WeaponList; //Lista broni które są zebrane
    public GameObject CurrentWeapon;
    //PlayerController będzie uzyskiwac dostep do skryptów które odpowiadają za kontrole nad bronią 
    //public Weapon CurrentWeapon //broń obecna to jest jedyna broń w obecnie aktywna w hierarchi jako dziecko Player.Weapons.<lista dzieci w tym przypadku wszystkich broni>
    //{
    //    get
    //    {
    //        // List<GameObject> list = transform.GetChild("Weapons").GetChildren(); //uzyskaj listę dzieci obiektu Weapons
    //        Transform Weapons = transform.Find("Weapons");
    //        List<GameObject> list = new List<GameObject>();
    //        foreach (GameObject gm in WeaponList)
    //        {
    //            //w danej chwili tylko jedna broń może być aktywna
    //            if (gm.activeSelf)
    //            {
    //                return gm;
    //            }
    //        }
    //        return null;
    //    }
    //}
    public void WeaponChange()
    {
        //Get the index of the current weapon in WeaponList then increment it and get the next weapon
    }
#endregion

#region Fields
    public Rigidbody2D body;
    public KeyCode ShootKey;
    public KeyCode ReloadKey;
    public KeyCode MoveKey;
    public KeyCode SprintKey;
    public KeyCode JumpKey;

    public bool IsMoving;
    public bool IsJumping;
    public bool IsSprinting;
    public bool IsStanding;  //w sensie stoi i nic nie robi
    public bool IsCrouching;
    public bool IsLying;     //postać leży
#endregion
    void OnCreate()
    {
        WeaponList = new List<GameObject>(MaxSize);
        CurrentWeapon = WeaponList[0];  //default weapon is melee 
    }
    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        Weapon curr = CurrentWeapon.GetComponent<Weapon>();
        if(Input.GetKey(ShootKey))
        {
            curr.Shoot();
        }
        if(Input.GetKey(ReloadKey))
        {
            curr.Reload();
        }
        if(Input.GetKey(MoveKey))
        {
            Move();
        }
        if(Input.GetKey(SprintKey))
        {
            Sprint();
        }
        if(Input.GetKey(JumpKey))
        {
            Jump();
        }
    }
    void Move()
    {
    
    }
    void Sprint()
    {
    
    }
    void Jump()
    {
    
    }
} 
