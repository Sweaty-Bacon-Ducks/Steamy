using UnityEngine.Networking;
using Platformer.Utility;
using UnityEngine;

public class Umbrella : RaycastBasedWeapon {

	[Client]
    public override void Shoot()
    {
        start = gameObject.FindObject("StartOfUmbrella").transform.position;
        end = LocalPlayer.info.PlayerCam.ScreenToWorldPoint(Input.mousePosition);
        CheckHit();
    }
}
