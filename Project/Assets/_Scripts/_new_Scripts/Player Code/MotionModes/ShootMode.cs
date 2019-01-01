using Steamy.Player;
using Steamy.Player.MotionModes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MotionModes/ShootMode")]
public class ShootMode : MotionMode
{

    public RaycastGunViewModel ViewModel;

    public override void ApplyMotion(CharacterViewModel characterViewModel)
    {
        throw new System.NotImplementedException();
    }

    void Update ()
    {
        if (Input.GetButton("Fire1"))
        {
            ViewModel.Attack();
        }
    }
}
