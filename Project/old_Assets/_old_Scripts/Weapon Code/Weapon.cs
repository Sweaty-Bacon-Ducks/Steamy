using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public delegate void WeaponEvent();
public abstract class Weapon : NetworkBehaviour
{
    protected const string PLAYER_TAG = "Player";

    [HideInInspector]
    public Player LocalPlayer;

    //public bool IsCollectable = true;
    public bool IsAutomatic = false;
    //public bool IsMelee = false;
    //public bool IsRaycast = false;
    //public bool IsPhysics = false;
    //public bool IsParticle = false;
    public bool IsReloading = false;
    public bool IsShooting = false;

    public int MaxAmmo;
    public int CurrentAmmo;
    public float ReloadTime;
    public float TriggerTime;

    public float Damage;
    public float Range;

    private void Awake()
    {
        LocalPlayer = GetComponent<Player>();
    }
    private void Start()
    {
        CurrentAmmo = MaxAmmo;
    }

    public virtual IEnumerator Reload()
    {
        IsReloading = true;
        Debug.Log("reloading weapon");

        yield return new WaitForSeconds(ReloadTime);

        CurrentAmmo = MaxAmmo;

        IsReloading = false;
    }
    public virtual void Start_Auto_Shoot()
    {
        throw new System.NotImplementedException("Base implementation of Start_Auto_Shoot() was used");
    }
    public virtual void Stop_Auto_Shoot()
    {
        throw new System.NotImplementedException("Base implementation of Stop_Auto_Shoot() was used");
    }
    public virtual void Shoot()
    {
        throw new System.NotImplementedException("Base implementation of Shoot() was used");
    }
    public virtual void Shoot(Vector3 start)
    {
        throw new System.NotImplementedException("Base implementation of Shoot(Vector3 start) was used");
    }
    public virtual void Shoot(Vector3 start,Vector3 end)
    {
        throw new System.NotImplementedException("Base implementation of Shoot(Vector3 start,Vector3 end) was used");
    }
    protected virtual void Collect(GameObject @object)
    {
        throw new System.NotImplementedException("Base implementation of Collect() was used");
    }
}

