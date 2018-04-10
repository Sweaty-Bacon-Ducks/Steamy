using System;
using UnityEngine;

[Serializable]
public class PlayerInfo
{
    #region ChildObjectsReferences
    public Weapon CurrentWeapon;
    public GameObject Arm;
    public Camera playerCam;
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

    [Header("Player status")]
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
}
