using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{ 
#region Weapon
    public Weapon CurrentWeapon;
#endregion

#region Fields
    [HideInInspector]
    public Rigidbody2D Body;

    [Header("Controls")]
    public KeyCode ShootKey;
    public KeyCode ReloadKey;
    public KeyCode MoveKey;
    public KeyCode SprintKey;
    public KeyCode JumpKey;

    [Header("Player status")]
    public bool IsMoving;
    public bool IsJumping;
    public bool IsSprinting;
    public bool IsStanding;  //w sensie stoi i nic nie robi
    public bool IsCrouching;
    public bool IsLying;     //postać leży
#endregion
    void Awake()
    {
        Body = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        if(Input.GetKey(ShootKey))
        {
            CurrentWeapon.Shoot();
        }
        if(Input.GetKey(ReloadKey))
        {
            CurrentWeapon.Reload();
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
