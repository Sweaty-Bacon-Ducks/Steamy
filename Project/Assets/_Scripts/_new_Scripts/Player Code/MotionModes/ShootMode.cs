using Steamy.Player;
using Steamy.Player.MotionModes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MotionModes/ShootMode")]
public class ShootMode : MotionMode
{
    public string AxisName;
    public override void ApplyMotion(CharacterViewModel characterViewModel)
    {
        if (Input.GetButton(AxisName))
        {
            characterViewModel.EquippedWeapon.Attack();
        }
    }
}
