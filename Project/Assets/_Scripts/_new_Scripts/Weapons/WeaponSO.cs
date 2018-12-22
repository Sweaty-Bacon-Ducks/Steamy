using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName ="Weapons/MeleeWeapon")]
public class WeaponSO : ScriptableObject {

    public string Name;
    public string Desc;
    public Sprite Sprite;
    public float Damage;
}
