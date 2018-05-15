using Platformer.Utility;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Player : NetworkBehaviour
{
    [SyncVar]
    public float HP;

    [Header("Player statistics")]
    public string Name = "Default";
    public float MaxHP = 100f;
    public float RespawnTime = 3f;

    public PlayerInfo info;

    private void Awake()
    {
        info.PlayerCam = GetComponentInChildren<Camera>();
        info.CurrentWeapon = info.Arm.GetComponentInChildren<Weapon>();
        info.AnimationController = GetComponentInChildren<Animator>();
        info.rotationMotor = GetComponent<MouswiseRotationMotor>();
        info.playerMotor = GetComponent<PlayerMotor>();
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Heal(float ammount)
    {
        HP += ammount;
        if (HP >= MaxHP)
        {
            HP = MaxHP;
        }
    }
    public void Damage(float damage)
    {
        HP -= damage;
        if (HP <= 0)
        {
            HP = 0;
        }
    }
    public void SetDefaults()
    {
        HP = MaxHP;

        info.IsDead = false;
        info.CurrentWeapon.CurrentAmmo = info.CurrentWeapon.MaxAmmo;
        info.IsControllable = true;
    }

    [Command]
    public void CmdPlayerShot(string _playerID,float damage)
    {
        Player hitPlayer = GameMaster.GetPlayer(_playerID);
        hitPlayer.Damage(damage);
    }
    public void SetupDisconnectButton()
    {
        var button = info.InGameMenu.FindObject("ButtonDisconnect").GetComponent<Button>();
        button.onClick.RemoveAllListeners();
        Debug.Log("Ustawiam przycisk rozłączenia");
        button.onClick.AddListener(NetworkManager.singleton.StopHost);
    }
    private IEnumerator RespawnTimer()
    {
        float counter = RespawnTime;
        do
        {
            info.RespawnTimer.GetComponent<TMPro.TMP_Text>().text = Math.Round(counter, 2).ToString();
            counter -= Time.deltaTime;
            yield return null;
        } while (counter > 0);
    }
    public IEnumerator Respawn() //void poniewa¿ jest to metoda, która subskrybuje zdarzenie
    {
        info.IsDead = true;
        info.IsControllable = false;
        info.PlayerModel.SetActive(false);
        info.Arm.SetActive(false);
        info.InGameMenu.SetActive(true);

        yield return StartCoroutine(RespawnTimer());

        Vector2 spawnPlace = SpawnPointManager.Instance.SpawnPoints[UnityEngine.Random.Range(0, SpawnPointManager.Instance.SpawnPoints.Count - 1)].transform.position;       //Losowanie spawn pointa
        transform.position = spawnPlace;

        info.IsDead = false;
        info.PlayerModel.SetActive(true);
        info.Arm.SetActive(true);
    }
}
