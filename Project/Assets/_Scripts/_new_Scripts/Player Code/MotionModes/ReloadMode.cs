using Steamy.Player;
using Steamy.Player.MotionModes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MotionModes/ReloadMode")]
public class ReloadMode : MotionMode
{
    public override void ApplyMotion(CharacterViewModel characterViewModel)
    {
        if (Input.GetButtonDown("Reload")) //R
        {
            characterViewModel.EquippedWeapon.Reload();
        }
    }
}
