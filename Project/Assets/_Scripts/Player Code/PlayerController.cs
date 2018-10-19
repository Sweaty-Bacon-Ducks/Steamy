using System;
using System.Threading.Tasks;
using UnityEngine;
using Platformer.Utility;
using System.Collections;

namespace Platformer
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerController : MonoBehaviour
    {
        private Player player;
        private float currentTime;

        void Awake()
        {
            player = GetComponent<Player>();

            player.info.Body = GetComponent<Rigidbody2D>();

            //EventManager.StartListening("OnPlayerDeath", () => StartCoroutine(player.Respawn()));
        }
        void Start()
        {
            player.SetupDisconnectButton();
            player.info.InGameMenu.SetActive(false);
        }

        void OnDestroy()
        {
            //EventManager.StopListening("OnPlayerDeath",() =>StartCoroutine(player.Respawn()));
        }

        private void Update()
        {
            if (!player.IsDead)
            {
                if (Input.GetKeyDown("k"))
                {
                    player.Rpc_TakeDamage(null, 10000f);
                }
                if (Input.GetKeyDown(player.info.MenuKey))
                {
                    player.info.InGameMenu.SetActive(!player.info.InGameMenu.activeSelf);
                    player.info.IsControllable = !player.info.IsControllable;
                }

                if (player.info.IsControllable)
                {
                    player.info.rotationMotor.RotateMousewise(player.info.PlayerCam, player.info.Arm);
                    if (!player.info.CurrentWeapon.IsReloading)
                    {
                        if (!player.info.CurrentWeapon.IsAutomatic)
                        {
                            if ((Input.GetButtonDown("Fire1") || Input.GetKeyDown(player.info.ShootKey)))
                            {
                                player.info.CurrentWeapon.Shoot();
                            }
                        }
                        else
                        {
                            if (Input.GetButton("Fire1") || Input.GetKey(player.info.ShootKey))
                            {
                                player.info.CurrentWeapon.Start_Auto_Shoot();
                            }
                            if (Input.GetButtonUp("Fire1") || Input.GetKeyUp(player.info.ShootKey))
                            {
                                player.info.CurrentWeapon.Stop_Auto_Shoot();
                            }
                        }
                        // dodane
                        if (Input.GetKeyDown(player.info.GrenadeKey))
                        {
                            GetComponent<Grenade>().Shoot();
                        }
                        if (Input.GetKey(player.info.ReloadKey))
                        {
                            player.info.CurrentWeapon.Reload();
                        }
                    }
                }
            }
        }
        void FixedUpdate()
        {
            if (player.info.IsControllable && !player.IsDead)
            {
                player.info.playerMotor.Move(player.info);

                if (Input.GetKey(player.info.JumpKey))
                {
                    player.info.playerMotor.Jump(player.info);
                }
                if (Input.GetKey(player.info.SprintKey))
                {
                    player.info.IsSprinting = true;
                    player.info.playerMotor.Sprint(player.info);
                }
                else
                {
                    player.info.IsSprinting = false;
                }
            }
        }

    }
}
