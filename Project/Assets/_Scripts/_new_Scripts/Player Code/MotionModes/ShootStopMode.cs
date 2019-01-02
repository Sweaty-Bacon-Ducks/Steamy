using Steamy.Player;
using Steamy.Player.MotionModes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MotionModes/ShootStopMode")]
public class ShootStopMode : MotionMode
{
    public string AxisName;
    public override void ApplyMotion(CharacterViewModel characterViewModel)
    {
        if (Input.GetButtonUp(AxisName))
        {
            characterViewModel.EquippedWeapon.StopAttack();
        }
    }
}
