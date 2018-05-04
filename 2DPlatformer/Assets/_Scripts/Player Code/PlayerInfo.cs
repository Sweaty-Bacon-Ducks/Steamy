using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using Platformer.Utility;

/// <summary>
/// Zawiera informacje o graczu
/// </summary>
[Serializable]
public class PlayerInfo
{
    #region ChildObjectsReferences
    public GameObject WeaponHolder;
    public List<GameObject> AllWeapons;
    public Weapon CurrentWeapon;
    public GameObject Arm;
    public Camera PlayerCam;
    public GameObject InGameMenu;
    public GameObject DisconnectButton;
    public GameObject RespawnTimer;
    public GameObject HUD;
    public GameObject PlayerModel;
    #endregion

    #region Motors
    public MouswiseRotationMotor rotationMotor;
    public PlayerMotor playerMotor;
    #endregion

    [HideInInspector]
    public Rigidbody2D Body;

    [Header("Player statistics")]
    public string Name = "Default";
    public float HP;
    public float MaxHP = 100f;
    public float RespawnTime = 3f;

    [Header("Controls")]
    public KeyCode ShootKey;
    public KeyCode ReloadKey;
    public KeyCode SprintKey;
    public KeyCode JumpKey;
    public KeyCode MenuKey;

    [Header("Player status")]
    public bool IsDead;
    public bool IsControllable;
    public bool IsMoving;
    public bool IsGrounded;
    public bool IsSprinting;
    public bool IsStanding;
    public bool IsCrouching;
    public bool IsLying;

    [Header("Movement")]
    public float Speed;
    public float JumpForce;
    public float SprintMult;
  
    public void SetupDisconnectButton()
    {
        var button = InGameMenu.FindObject("ButtonDisconnect").GetComponent<Button>();
        button.onClick.RemoveAllListeners();
        Debug.Log("Ustawiam przycisk rozłączenia");
        button.onClick.AddListener(NetworkManager.singleton.StopHost);
    }
    public void Heal(float ammount)
    {
        HP += ammount;
        if (HP >= MaxHP)
        {
            HP = MaxHP;
        }
    }
    public void Damage(float damage)
    {
        HP -= damage;
        if (HP <= 0)
        {
            HP = 0;
        }
    }

    public void Initialize(Transform player)
    {
        foreach (Transform tr in player)
        {
            if (tr != player.root && !AllWeapons.Contains(tr.gameObject))
            {
                AllWeapons.Add(tr.gameObject);
                Debug.Log("The object " + tr.name + " was loaded!");
            }
        }
    }
}
