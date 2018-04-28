using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleWeapon : Weapon
{
    public new ParticleSystem[] particleSystem;

    void Awake()
    {
        particleSystem[1].Stop();

        Start_Shoot += StartShootParticleEffect;
        Stop_Shoot += StopShootParticleEffect;
    }
    public override void Shoot()
    {
        if (CurrentAmmo > 0)
        {
            CurrentAmmo--;
            IsShooting = true;
        }
        else
        {
            IsShooting = false;
            StopShootParticleEffect();
            StartCoroutine(Reload());
        }
    }

    private void StopShootParticleEffect()
    {
        particleSystem[0].Play();
        particleSystem[1].Stop();
    }
    private void StartShootParticleEffect()
    {
        particleSystem[0].Stop();
        particleSystem[1].Play();
    }
}
