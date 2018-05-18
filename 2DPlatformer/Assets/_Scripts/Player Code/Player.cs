using Platformer.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Player : NetworkBehaviour
{
    [SyncVar]
    public float HP;
    [SyncVar]
    public bool IsDead;

    //Lista aktywnych buffów
    List<Buff> activeEffects = new List<Buff>();

    [Header("Player statistics")]
    public string Name = "Default";
    public float MaxHP = 100f;

    [SerializeField]
    private Behaviour[] disableOnDeath;
    private bool[] wasEnabled;

    public PlayerInfo info;

    private void Awake()
    {
        info.PlayerCam = GetComponentInChildren<Camera>();
        var weapons = GetComponents<Weapon>();
        foreach (var item in weapons)
        {
            if (item.GetType() != typeof(PhysicsWeapon))
            {
                info.CurrentWeapon = item;
                break;
            }
        }
        info.AnimationController = GetComponentInChildren<Animator>();
        info.rotationMotor = GetComponent<MouswiseRotationMotor>();
        info.playerMotor = GetComponent<PlayerMotor>();
    }
    public void Heal(float ammount)
    {
        HP += ammount;
        if (HP >= MaxHP)
        {
            HP = MaxHP;
        }
    }
    [ClientRpc]
    public void Rpc_TakeDamage(float damage)
    {
        HP -= damage;
        if (HP <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        for (int i = 0; i < disableOnDeath.Length; i++)
        {
            disableOnDeath[i].enabled = false;
            Collider2D _col = GetComponent<Collider2D>();
            if (_col != null)
            {
                _col.enabled = false;
            }
            SpriteRenderer spriteRenderer = info.PlayerModel.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.enabled = false;
            }
        }
        IsDead = true;

        StartCoroutine(Respawn());
    }

    [Command]
    public void Cmd_PlayerShot(string _playerID, float damage)
    {
        Player hitPlayer = GameMaster.GetPlayer(_playerID);
        hitPlayer.Rpc_TakeDamage(damage);
        Debug.Log("Trafiony: " + _playerID + " ma teraz " + hitPlayer.HP + "HP");
    }
    public void Setup()
    {
        wasEnabled = new bool[disableOnDeath.Length];
        for (int i = 0; i < wasEnabled.Length; i++)
        {
            wasEnabled[i] = disableOnDeath[i].enabled;
        }

        SetDefaults();
    }
    public void SetDefaults()
    {
        IsDead = false;
        HP = MaxHP;

        for (int i = 0; i < disableOnDeath.Length; i++)
        {
            disableOnDeath[i].enabled = wasEnabled[i];
        }
        Collider2D _col = GetComponent<Collider2D>();
        if (_col != null)
        {
            _col.enabled = true;
        }
        SpriteRenderer spriteRenderer = info.PlayerModel.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.enabled = true;
        }

        info.CurrentWeapon.CurrentAmmo = info.CurrentWeapon.MaxAmmo;
        info.IsControllable = true;
    }
    public void SetupDisconnectButton()
    {
        var button = info.InGameMenu.FindObject("ButtonDisconnect").GetComponent<Button>();
        button.onClick.RemoveAllListeners();
        Debug.Log("Ustawiam przycisk rozłączenia");
        button.onClick.AddListener(NetworkManager.singleton.StopHost);
    }
    private IEnumerator RespawnTimer(float RespawnTime)
    {
        Vector3 oldPos = transform.position;
        float counter = RespawnTime;
        do
        {
            //info.RespawnTimer.GetComponent<TMPro.TMP_Text>().text = Math.Round(counter, 2).ToString();
            counter -= Time.deltaTime;
            transform.position = oldPos;
            yield return null;
        } while (counter > 0);
    }
    public IEnumerator Respawn() //void poniewa¿ jest to metoda, która subskrybuje zdarzenie
    {
        yield return StartCoroutine(RespawnTimer(GameMaster.Instance.GameSettings.RespawnTime));

        Vector2 spawnPlace = SpawnPointManager.Instance.SpawnPoints[UnityEngine.Random.Range(0, SpawnPointManager.Instance.SpawnPoints.Count - 1)].transform.position;       //Losowanie spawn pointa
        transform.position = spawnPlace;

        SetDefaults();
    }

    //Metody do przyjmowania i usuwania buffów i debuffów

    public void Subscribe(Buff effect)
    {
        foreach (Buff item in activeEffects)
        {
            if (item.activeEffect == effect.activeEffect) return;
        }

        effect.instance = StartCoroutine(effect.Healing(this));
        activeEffects.Add(effect);
    }

    public void Unsubscribe(Coroutine coro)
    {
        foreach (Buff item in activeEffects)
        {
            if (item.instance == coro)
            {
                StopCoroutine(item.instance);
                activeEffects.Remove(item);
            }
        }
    }

}
