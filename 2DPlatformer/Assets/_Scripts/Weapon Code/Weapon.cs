using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public bool IsCollectable;
    public bool IsAutomatic;
    public bool IsMelee;
    public bool IsRaycast;
    public bool IsPhysics;
    public int MaxAmmo;
    public int CurrentAmmo;
    public abstract void Shoot();
    public abstract void Reload();   //Może użyć IEnumerator
    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Collided with " + col.name);
        if (col.tag == "Player")
        {
            Collect(col.gameObject);
            Destroy(gameObject);
        }
    }
    protected virtual void Collect(GameObject player)
    {
        PlayerController Player = player.gameObject.GetComponent<PlayerController>();
        //Player.WeaponList.Add(gameObject);
    }
}

