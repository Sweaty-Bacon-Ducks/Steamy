using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable
{
    /// <returns>true if object is destroyed</returns>
    void Damage(double amount);
}
