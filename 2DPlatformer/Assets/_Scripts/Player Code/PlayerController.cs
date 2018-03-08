using System;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    #region Fields
    public GameObject InGameMenu;
    public Rigidbody2D Body;
    public bool IsControllable = true;

    [Header("Player statistics")]
    [SerializeField]
    private new string name = "Default";
    [SerializeField]
    private float hp;
    [SerializeField]
    private float maxHP = 100;
    [SerializeField]
    private float shield;
    [SerializeField]
    private float maxShield = 100;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float jumpForce;


    [Header("Controls")]
    [SerializeField]
    private KeyCode ShootKey;
    [SerializeField]
    private KeyCode ReloadKey;
    [SerializeField]
    private KeyCode SprintKey;
    [SerializeField]
    private KeyCode JumpKey;
    [SerializeField]
    private KeyCode PauseKey;

    [Header("Player status")]
    [SerializeField]
    private bool IsMoving;
    [SerializeField]
    private bool IsGrounded;
    [SerializeField]
    private bool IsSprinting;
    [SerializeField]
    private bool IsStanding;
    [SerializeField]
    private bool IsCrouching;
    [SerializeField]
    private bool IsLying;

    #endregion

    #region Weapon
    public Weapon CurrentWeapon;
    #endregion

    #region Properties
    public string Name
    {
        get
        {
            return name;
        }
    }

    public float HP
    {
        get
        {
            return hp;
        }
    }

    public float MaxHP
    {
        get
        {
            return maxHP;
        }
    }

    public float Speed
    {
        get
        {
            return Speed;
        }
    }

    public float JumpForce
    {
        get
        {
            return JumpForce;
        }
    }

    public float Shield
    {
        get
        {
            return shield;
        }
    }

    public float MaxShield
    {
        get
        {
            return maxShield;
        }
    }
    #endregion

    void Start()
    {
        maxHP = hp;
    }

    void Awake()
    {
        Body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(PauseKey) && IsControllable)
        {
            IsControllable = false;
            ShowInGameMenu();
        }
        else if (Input.GetKeyDown(PauseKey) && !IsControllable)
        {
            IsControllable = true;
            HideInGameMenu();
        }
    }

    private void HideInGameMenu()
    {
        InGameMenu.SetActive(false);
    }

    private void ShowInGameMenu()
    {
        InGameMenu.SetActive(true);
    }

    void FixedUpdate()
    {
        if (IsControllable)
        {
            Move();
            if (Input.GetKey(ShootKey))
            {
                CurrentWeapon.Shoot();
            }
            if (Input.GetKey(ReloadKey))
            {
                CurrentWeapon.Reload();
            }
            if (Input.GetKey(JumpKey) && IsGrounded)
            {
                Jump();
                IsGrounded = !IsGrounded;
            }
            if (Input.GetKey(SprintKey))
            {
                IsSprinting = true;
                Sprint();
            }
            else
            {
                IsSprinting = false;
            }
        }
    }

    #region PlayerMotor
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
        if (IsGrounded == false && Input.GetAxis("Horizontal") != 0)
        {
            Body.velocity = new Vector2(Body.velocity.x * 2, Body.velocity.y);
        }
    }
    void Jump()
    {
        // Na razie bez double jump.
        if (!IsGrounded)
        {
            Vector2 jump = new Vector2(0, JumpForce);
            Body.AddForce(jump, ForceMode2D.Impulse);
        }
    }
    public void Heal(float ammount)
    {
        hp += ammount;
        if (hp >= maxHP)
        {
            hp = maxHP;
        }
    }
    public void Damage(float damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            //Kill the player
            Destroy(gameObject);
        }
    }
    #endregion
}
