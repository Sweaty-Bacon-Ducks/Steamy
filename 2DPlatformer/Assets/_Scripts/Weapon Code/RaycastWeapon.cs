using UnityEngine;
using UnityEngine.Networking;
using Platformer.Utility;
public class RaycastWeapon : Weapon
{
    [SerializeField]
    private LayerMask layerMask;

    private Vector3 start;
    private Vector3 end;

    [Client]
    public override void Shoot()
    {
        CurrentAmmo--;

        if (CurrentAmmo <= 0)
        {
            StartCoroutine(Reload());
        }

        start = gameObject.FindObject("StartOfUmbrella").transform.position;
        end = LocalPlayer.info.PlayerCam.ScreenToWorldPoint(Input.mousePosition);
        Debug.DrawLine(start, end, Color.red);
        RaycastHit2D hit;
        if (hit = Physics2D.Raycast(start, end-start, Range, layerMask))
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