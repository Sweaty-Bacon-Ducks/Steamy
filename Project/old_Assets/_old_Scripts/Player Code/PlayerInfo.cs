using System;
using UnityEngine;

/// <summary>
/// Zawiera informacje o graczu
/// </summary>
[Serializable]
public class PlayerInfo
{
    #region ChildObjectsReferences
    [HideInInspector]
    public Camera PlayerCam;
    [HideInInspector]
    public Weapon CurrentWeapon;
    [HideInInspector]
    public Animator AnimationController;
    [HideInInspector]
    public Rigidbody2D Body;
    public GameObject Arm;
    public GameObject InGameMenu;
    public GameObject DisconnectButton;
    public GameObject RespawnTimer;
    public GameObject HUD;
    public GameObject PlayerModel;

    #endregion

    #region Motors
    [HideInInspector]
    public MouswiseRotationMotor rotationMotor;
    [HideInInspector]
    public PlayerMotor playerMotor;
    #endregion

    [Header("Selected Prefab")]
    public int SelectedAvatar;

    [Header("Controls")]
    public KeyCode ShootKey;
    public KeyCode ReloadKey;
    public KeyCode SprintKey;
    public KeyCode JumpKey;
    public KeyCode MenuKey;
    public KeyCode GrenadeKey;

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
   

    //Private constructor disallows the object from being created
    private PlayerInfo(){   }
}
