using UnityEngine.Networking;
using Platformer.Utility;
using UnityEngine;

public class RaycastBasedWeapon : Weapon {

    [SerializeField]
    private LayerMask layerMask;

    protected Vector3 start;
    protected Vector3 end;

    [Client]
    public override void Shoot()
    {
        CurrentAmmo--;

        if (CurrentAmmo <= 0)
        {
            StartCoroutine(Reload());
        }
    }

    public virtual void CheckHit()
    {
        Debug.DrawLine(start, end, Color.red);
        RaycastHit2D hit;
        if (hit = Physics2D.Raycast(start, end - start, Range, layerMask))
        {
            if (hit.transform.CompareTag(PLAYER_TAG))
            {
                string _playerID = hit.transform.name;
                Debug.Log("Trafiono " + _playerID);
                LocalPlayer.Cmd_PlayerShot(_playerID, Damage);
            }
        }
    }
}
