using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Steamy.Weapons
{
    public abstract class WeaponViewModel : MonoBehaviour
    {
        public abstract void Attack();
        public abstract void StopAttack();
        public abstract void Reload();
    }
}
