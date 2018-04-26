using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Platformer
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Player Information")]
        [SerializeField]
        public PlayerInfo info;

        void Start()
        {
            info.WeaponHolder = info.Arm;
            info.Initialize(info.WeaponHolder.transform);
            info.CurrentWeapon = info.AllWeapons[0].GetComponent<Weapon>();
            info.HP = info.MaxHP;
            info.CurrentWeapon.CurrentAmmo = info.CurrentWeapon.MaxAmmo;
            info.IsControllable = true;

            info.SetupDisconnectButton();
            info.DisconnectButton.SetActive(false);
        }

        void Awake()
        {
            info.Body = GetComponent<Rigidbody2D>();
        }
        private void Update()
        {
            if (Input.GetKeyDown(info.MenuKey))
            {
                info.DisconnectButton.SetActive(!info.DisconnectButton.activeSelf);
                info.IsControllable = !info.IsControllable;
            }
            if (info.IsControllable)
            {
                info.rotationMotor.RotateMousewise(info.PlayerCam, info.Arm);

                if ((Input.GetAxis("Fire1") != 0) || Input.GetKey(info.ShootKey))
                {
                    info.CurrentWeapon.Start_Shoot?.Invoke();
                    info.CurrentWeapon.Shoot();
                }
                if (!info.CurrentWeapon.IsReloading && Input.GetKey(info.ReloadKey))
                {
                    info.CurrentWeapon.Reload();
                }
                if (Input.GetKeyUp(info.ShootKey))
                {
                    info.CurrentWeapon.Stop_Shoot?.Invoke();
                }
            }
        }
        void FixedUpdate()
        {
            if (info.IsControllable)
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
        }
    }
}
