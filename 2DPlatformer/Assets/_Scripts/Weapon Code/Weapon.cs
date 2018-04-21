using UnityEngine;
using System.Collections;
using System;

public delegate void WeaponEvent();
public abstract class Weapon : MonoBehaviour
{
    public WeaponEvent Start_Shoot;
    public WeaponEvent Stop_Shoot;

    public bool IsCollectable = true;
    public bool IsAutomatic = false;
    public bool IsMelee = false;
    public bool IsRaycast = false;
    public bool IsPhysics = false;
    public bool IsParticle = false;
    public bool IsReloading = false;
    public bool IsShooting = false;

    public int MaxAmmo;
    public int CurrentAmmo;
    public float ReloadTime;
    public float TriggerTime;

    public Sprite GUISprite;
    
    private void Start()
    {
        MaxAmmo = Int32.MaxValue;
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
    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Collided with " + col.name);
        if (col.tag == "Player")
        {
            Collect(col.gameObject);
            Destroy(gameObject);
        }
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

