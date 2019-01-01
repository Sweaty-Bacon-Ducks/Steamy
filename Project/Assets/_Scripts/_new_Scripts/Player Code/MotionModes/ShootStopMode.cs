using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MotionModes/ShootStopMode")]
public class ShootStopMode : MotionMode
{

    public RaycastGunViewModel ViewModel;

    void Update()
    {
        if (Input.GetButtonUp("Fire1"))
        {
            ViewModel.ResetTriggerTime();
        }
    }
}
