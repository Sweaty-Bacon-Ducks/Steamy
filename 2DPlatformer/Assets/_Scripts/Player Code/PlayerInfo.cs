using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

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
    public float MaxHP = 100;

    [Header("Controls")]
    public KeyCode ShootKey;
    public KeyCode ReloadKey;
    public KeyCode SprintKey;
    public KeyCode JumpKey;
    public KeyCode MenuKey;

    [Header("Player status")]
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
        button.onClick.AddListener(NetworkManager.singleton.StopHost);
        //button.onClick.AddListener(LoadMainMenuScene);
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
    public void PlayerDeath(GameObject player)
    {
        // Kill the player
        UnityEngine.Object.Destroy(player);
    }
    public void LoadMainMenuScene()
    {
        SceneManager.LoadScene("MenuTest");
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
