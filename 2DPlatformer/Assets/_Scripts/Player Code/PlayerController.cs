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

        void Awake()
        {
            player = GetComponent<Player>();

            player.info.Body = GetComponent<Rigidbody2D>();

            EventManager.StartListening("OnPlayerDeath", () => StartCoroutine(player.Respawn()));
        }
        void Start()
        {
            player.SetupDisconnectButton();
            player.info.InGameMenu.SetActive(false);
        }
        private void OnEnable()
        {
            //Wszystkie statystyki gracza, maj¹ce byæ zresetowane po œmierci gracza musz¹ byæ ustawiane w OnEnable
            player.SetDefaults();
        }

        void OnDestroy()
        {
            EventManager.StopListening("OnPlayerDeath",() =>StartCoroutine(player.Respawn()));
        }
        
        private void Update()
        {
            if (!player.info.IsDead)
            {
                if (Input.GetKeyDown("o"))
                {
                    EventManager.TriggerEvent("OnPlayerDeath");
                }
                if (Input.GetKeyDown(player.info.MenuKey))
                {
                    player.info.InGameMenu.SetActive(!player.info.InGameMenu.activeSelf);
                    player.info.IsControllable = !player.info.IsControllable;
                }

                if (player.info.IsControllable)
                {
                    player.info.rotationMotor.RotateMousewise(player.info.PlayerCam, player.info.Arm);

                    if (Input.GetButtonDown("Fire1") || Input.GetKey(player.info.ShootKey))
                    {
                        player.info.CurrentWeapon.Start_Shoot?.Invoke();
                        player.info.CurrentWeapon.Shoot();
                    }
                    if (!player.info.CurrentWeapon.IsReloading && Input.GetKey(player.info.ReloadKey))
                    {
                        player.info.CurrentWeapon.Reload();
                    }
                    if (Input.GetButtonUp("Fire1") || Input.GetKeyUp(player.info.ShootKey))
                    {
                        player.info.CurrentWeapon.Stop_Shoot?.Invoke();
                    }
                }
            }
        }
        void FixedUpdate()
        {
            if (player.info.IsControllable && !player.info.IsDead)
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
