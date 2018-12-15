using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponViewModel : MonoBehaviour, IAttackable
{
    public abstract void Attack();
}
