using UnityEngine;
using UnityEngine.Networking;
public class PlayerController : MonoBehaviour
{
    [Header("Player Information")]
    [SerializeField]
    public PlayerInfo info;

    void Start()
    {
        info.MaxHP = info.HP;
    }

    void Awake()
    {
        info.Body = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        //Obróć rękę odpowiednio
        info.rotationMotor.RotateMousewise(info.playerCam, info.Arm);

        if ((Input.GetAxis("Fire1") != 0) || Input.GetKey(info.ShootKey))
        {
            info.CurrentWeapon.Shoot();
        }
        if (Input.GetKey(info.ReloadKey))
        {
            info.CurrentWeapon.Reload();
        }
    }
    void FixedUpdate()
    {
        info.playerMotor.Move(info);
        
        if (Input.GetKey(info.JumpKey))
        {
            info.playerMotor.Jump(info);
        }
        if (Input.GetKey(info.SprintKey))
        {
            info.IsSprinting = true;
            info.playerMotor.Sprint(info);
        }
        else
        {
            info.IsSprinting = false;
        }
        
    }

    public void Heal(float ammount)
    {
        info.HP += ammount;
        if (info.HP >= info.MaxHP)
        {
            info.HP = info.MaxHP;
        }
    }
    public void Damage(float damage)
    {
        info.HP -= damage;
        if (info.HP <= 0)
        {
            info.HP = 0;
        }
    }
    public void PlayerDeath()
    {
        // Kill the player
        Destroy(gameObject);
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