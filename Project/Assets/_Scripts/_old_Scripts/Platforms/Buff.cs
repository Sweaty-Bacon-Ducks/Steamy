using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
[Serializable]
public class Buff : ScriptableObject
{
    [SerializeField] private float healingSpeed = 0.5f;
    [SerializeField] private float healingValue = 1f;
    [SerializeField] private float maxHealingValue = 100f;
    private float acumulatedHealingValue = 0;

    public Coroutine instance;
    public enum effectTypes { Healing };
    [SerializeField] public effectTypes activeEffect = effectTypes.Healing;


    public void Dispose(Player pc)
    {
        pc.Unsubscribe(instance);
    }




    public IEnumerator Healing(Player pc)
    {
        if (pc.HP < pc.MaxHP)
        {
            while (acumulatedHealingValue < maxHealingValue)
            {
                pc.Heal(healingValue);
                acumulatedHealingValue += healingValue;
                Debug.Log(acumulatedHealingValue);
                yield return new WaitForSeconds(healingSpeed);
            }

        }
        acumulatedHealingValue = 0;
        Dispose(pc);
    }


}
