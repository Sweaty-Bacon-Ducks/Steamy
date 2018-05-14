using System;
using System.Threading.Tasks;
using UnityEngine;
using Platformer.Utility;

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

            info.SetupDisconnectButton();
            info.InGameMenu.SetActive(false);
        }
        private void OnEnable()
        {
            //Wszystkie statystyki gracza, maj¹ce byæ zresetowane po œmierci gracza musz¹ byæ ustawiane w OnEnable
            info.IsDead = false;
            info.CurrentWeapon = info.AllWeapons[0].GetComponent<Weapon>();
            info.HP = info.MaxHP;
            info.CurrentWeapon.CurrentAmmo = info.CurrentWeapon.MaxAmmo;
            info.IsControllable = true;
        }

        void OnDestroy()
        {
            EventManager.StopListening("OnPlayerDeath", Respawn);
        }

        void Awake()
        {
            info.Body = GetComponent<Rigidbody2D>();

            EventManager.StartListening("OnPlayerDeath", Respawn);
        }
        private void Update()
        {
            if (!info.IsDead)
            {
                if (Input.GetKeyDown("o"))
                {
                    EventManager.TriggerEvent("OnPlayerDeath");
                }
                if (Input.GetKeyDown(info.MenuKey))
                {
                    info.InGameMenu.SetActive(!info.InGameMenu.activeSelf);
                    info.IsControllable = !info.IsControllable;
                }

                if (info.IsControllable)
                {
                    info.rotationMotor.RotateMousewise(info.PlayerCam, info.Arm);

                    if (Input.GetButtonDown("Fire1") || Input.GetKey(info.ShootKey))
                    {
                        info.CurrentWeapon.Start_Shoot?.Invoke();
                        info.CurrentWeapon.Shoot();
                    }
                    if (!info.CurrentWeapon.IsReloading && Input.GetKey(info.ReloadKey))
                    {
                        info.CurrentWeapon.Reload();
                    }
                    if (Input.GetButtonUp("Fire1") || Input.GetKeyUp(info.ShootKey))
                    {
                        info.CurrentWeapon.Stop_Shoot?.Invoke();
                    }
                }
            }
        }
        void FixedUpdate()
        {
            if (info.IsControllable && !info.IsDead)
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
        private async Task RespawnTimer()
        {
            float counter = info.RespawnTime;
            do
            {
                info.RespawnTimer.GetComponent<TMPro.TMP_Text>().text = Math.Round(counter, 2).ToString();
                counter -= Time.deltaTime;
                await TimeSpan.FromSeconds(Time.deltaTime);
            } while (counter > 0);
        }
        public async void Respawn() //void poniewa¿ jest to metoda, która subskrybuje zdarzenie
        {
            info.IsDead = true;
            info.IsControllable = false;
            info.PlayerModel.SetActive(false);
            info.Arm.SetActive(false);
            info.InGameMenu.SetActive(true);

            try
            {
                await RespawnTimer();
            }
            catch (MissingReferenceException)
            {
                Debug.Log("Player was destroyed");
            }
            Vector2 spawnPlace = SpawnPointManager.Instance.SpawnPoints[UnityEngine.Random.Range(0, SpawnPointManager.Instance.SpawnPoints.Count - 1)].transform.position;       //Losowanie spawn pointa
            transform.position = spawnPlace;

            info.IsDead = false;
            info.PlayerModel.SetActive(true);
            info.Arm.SetActive(true);
        }
    }
}
