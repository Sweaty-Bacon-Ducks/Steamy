using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleWeapon : Weapon
{
    public new ParticleSystem[] particleSystem;

    void Start()
    {
        Start_Shoot += StartParticleEffect;
        Stop_Shoot += StopParticleEffect;
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
            StopParticleEffect();
            StartCoroutine(Reload());
        }
    }

    private void StopParticleEffect()
    {
        particleSystem[1].Stop();
    }
    private void StartParticleEffect()
    {
        particleSystem[1].Play();
    }
}
