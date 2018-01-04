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
    public bool IsJumping;  // czepiając się, można by zmienić IsJumping na cos w stylu IsGrounded, bo bycie w powietrzu nie zawsze == skakanie
    public bool IsSprinting;
    public bool IsStanding;  //w sensie stoi i nic nie robi
    public bool IsCrouching;
    public bool IsLying;     //postać leży

    [Header("Movement")]
    public float Speed;
    public float JumpForce;
#endregion
    void Awake()
    {
        Body = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        // Nie w ifie, bo move to więcej niż jeden klawisz. Ew. można dać np. GetKey(MoveLeftKey) || GetKey(MoveRightKey)
        Move();

        if(Input.GetKey(ShootKey))
        {
            CurrentWeapon.Shoot();
        }
        if(Input.GetKey(ReloadKey))
        {
            CurrentWeapon.Reload();
        }
        //if(Input.GetKey(MoveKey))
        //{
        //    Move();
        //}
        if(Input.GetKey(SprintKey))
        {
            IsSprinting = true;
            Sprint();
        }
        else
        {
            IsSprinting = false;
        }
        if(Input.GetKey(JumpKey))
        {
            Jump();
        }
    }
    void Move()
    {
        // Czy jest potrzebne zarówno IsMoving i IsStanding?
        if (Body.velocity.x == 0 && Body.velocity.y == 0)
        {
            IsMoving = false;
            IsStanding = true;
        }
        else
        {
            IsMoving = true;
            IsStanding = false;
        }

        float moveHorizontal = Input.GetAxis("Horizontal");
        // Body.velocity, bo w ten sposób ruch jest dużo bardziej responsywny.
        Body.velocity = new Vector2(moveHorizontal * Speed, Body.velocity.y);
    }
    void Sprint()
    {
        // Sprint działa tylko gdy jest wciśnięty jakiś klawisz ruchu i nie w powietrzu.
        if (IsJumping == false && Input.GetAxis("Horizontal") != 0)
        {
            Body.velocity = new Vector2(Body.velocity.x * 2, Body.velocity.y);
        }
    }
    void Jump()
    {
        // Na razie bez double jump.
        if (IsJumping == false)
        {
            Vector2 jump = new Vector2(0, JumpForce);
            Body.AddForce(jump, ForceMode2D.Impulse);
        }
    }
    void OnCollisionEnter2D()
    {
        IsJumping = false;
    }
    void OnCollisionExit2D()
    {
        IsJumping = true;
    }
}
