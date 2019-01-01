using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadMode : MotionMode
{


	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ViewModel.Reload();
        }
    }
}
