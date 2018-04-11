using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleWeapon : Weapon
{
    public new ParticleSystem[] particleSystem;

    void Start()
    {
        StopParticleEffect(1);
    }

    public override void Shoot()
    {
        if (CurrentAmmo > 0)
        {
            CurrentAmmo--;
            StartParticleEffect(0);
        }
        else
        {
            StartCoroutine(Reload());
        }
    }

    private void StopParticleEffect(int index)
    {
        particleSystem[index].Stop();
    }
    private void StartParticleEffect(int index)
    {
        particleSystem[index].Play();
    }
}
