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
        if (Input.GetKey(ShootKey))
        {
            CurrentWeapon.Shoot();
        }
        if (Input.GetKey(ReloadKey))
        {
            CurrentWeapon.Reload();
        }
        if (Input.GetKey(MoveKey))
        {
            Move();
        }
        if (Input.GetKey(SprintKey))
        {
            Sprint();
        }
        if (Input.GetKey(JumpKey))
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
}
