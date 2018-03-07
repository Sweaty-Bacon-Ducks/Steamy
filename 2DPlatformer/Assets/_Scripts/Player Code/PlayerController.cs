using UnityEngine;
public class PlayerController : MonoBehaviour
{
    #region Weapon
    public Weapon CurrentWeapon;
    #endregion

    #region Fields
    [HideInInspector]
    public Rigidbody2D Body;

    [Header("Player statistics")]
    [SerializeField]
    private new string name = "Default";
    [SerializeField]
    private float hp;
    [SerializeField]
    private float maxHP = 1;

    [Header("Controls")]
    public KeyCode ShootKey;
    public KeyCode ReloadKey;
    //public KeyCode MoveKey;
    public KeyCode SprintKey;
    public KeyCode JumpKey;

    [Header("Player status")]
    public bool IsMoving;
    public bool IsGrounded;  // czepiając się, można by zmienić IsGrounded na cos w stylu IsGrounded, bo bycie w powietrzu nie zawsze == skakanie
    public bool IsSprinting;
    public bool IsStanding;  
    public bool IsCrouching;
    public bool IsLying;

    [Header("Movement")]
    public float Speed;
    public float JumpForce;
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
    #endregion

    void Start()
    {
        maxHP = hp;
    }

    void Awake()
    {
        Body = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
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
        if (Input.GetKey(JumpKey))
        {
            Jump();
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
        if (IsGrounded == false)
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
    //Trzeba się zastanowić jak będziemy rozpoznawać poszczególne obiekty i które przez tagi a które przez warstwy
    /*void OnCollisionEnter2D()
    {
        IsGrounded = false;
    }
    void OnCollisionExit2D()
    {
        IsGrounded = true;
    }
    */
}
