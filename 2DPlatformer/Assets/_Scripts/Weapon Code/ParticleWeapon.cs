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
    public void StopParticleEffect(int index)
    {
        particleSystem[index].Stop();
    }
    public void StartParticleEffect(int index)
    {
        particleSystem[index].Play();
    }
    public override void Shoot()
    {
        if (CurrentAmmo-- > 0)
        {
            StartParticleEffect(0);
        }
    }
}
