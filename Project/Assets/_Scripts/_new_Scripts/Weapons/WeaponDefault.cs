using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName ="Weapons/MeleeWeapon")]
public class WeaponDefault : ScriptableObject {

    public string WeaponName;
    public string Desc;
    public Sprite WeaponSprite;
    public float Damage;
}
