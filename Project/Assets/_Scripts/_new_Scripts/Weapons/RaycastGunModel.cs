using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapons/RaycastGun")]
public class RaycastGunModel : ScriptableObject {

    public float BulletSpread;
    public int BulletCount;
    public int MagazineSize;

    public float RaycastLength;

    public int BulletsInMagazine;
    public float ReloadTimer;
    public float FireTimer;
    public float TriggerTimer;
}
