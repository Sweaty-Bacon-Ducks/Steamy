using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastGunViewModel : WeaponViewModel
{
    private RaycastGunModel model;

    public RaycastGunDefault Default;
    public Transform ProjectileSpawn;
    public GameObject LineRendererPrefab;

    private Vector3 rayDirection;
    private LineRenderer activeRay;

    private void Awake()
    {
        model = Default.LoadFromDefaults();
    }

    private void Update() //TMP dopóki nie ustalimy gdzie input powinien być
    {
        if (Input.GetButton("Fire1"))
        {
            Attack();
        }

        if (Input.GetButtonUp("Fire1"))
        {
            ResetTriggerTime();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }

    public override void Attack()
    {
        model.TriggerTimer.Value += Time.deltaTime;
        if (Time.time > model.FireTimer.Value && model.BulletsInMagazine.Value >= 1 && model.Reloading.Value == false && model.TriggerTimer.Value >= model.TimeToFire.Value)
        {
            model.FireTimer.Value = Time.time + model.FireRate.Value;

            ExecuteAttack();
        }
    }



    /// <summary>
    /// For now Instantiates ray for specified time and destroys it after
    /// </summary>
    private IEnumerator ShotEffect()
    {
        activeRay = Instantiate(LineRendererPrefab).GetComponent<LineRenderer>();
        LineRenderer newRay = activeRay;
        yield return new WaitForSeconds(model.ShotDuration.Value);
        Destroy(newRay.gameObject);
    }

    /// <summary>
    /// Function called on pressing the ReloadButton
    /// </summary>
    public void Reload()
    {
        if (model.BulletsInMagazine.Value < model.MagazineSize.Value && model.Reloading.Value == false)
        {
            StartCoroutine(ExecuteReload());
        }
    }

    private IEnumerator ExecuteReload()
    {
        model.Reloading.Value = true;
        yield return new WaitForSeconds(model.ReloadTime.Value);
        model.Reloading.Value = false;
        model.BulletsInMagazine.Value = model.MagazineSize.Value;
    }

    private void ExecuteAttack()
    {
        model.BulletsInMagazine.Value--;

        for (int i = 0; i < model.BulletCount.Value; ++i)
        {
            model.PenetrationDamage.Value = model.Damage.Value;
            model.PenetrationLeft.Value = model.BulletPenetration.Value;

            StartCoroutine(ShotEffect());

            Vector3 direction = ProjectileSpawn.right;
            direction.y += Random.Range(-model.BulletSpread.Value, model.BulletSpread.Value); // Creating bullet spread

            Vector3 rayOrigin = ProjectileSpawn.position;
            activeRay.SetPosition(0, rayOrigin);

            // Save every object on the ray's path and iterate over them to check how many were penetrated and damaged
            RaycastHit[] hit;
            hit = Physics.RaycastAll(rayOrigin, direction, model.RaycastLength.Value);
            if (hit.Length > 0)
            {
                ShootOneRay(hit);
            }
            else
            {
                activeRay.SetPosition(1, rayOrigin + (direction * model.RaycastLength.Value));
            }
        }
    }

    /// <summary>
    /// Logic behind drawing ray, penetrating and dealing damage.
    /// For example, if BulletCount = 5, then this function gets called 5 times
    /// </summary>
    private void ShootOneRay(RaycastHit[] hit)
    {
        for (int j = 0; j < hit.Length; ++j)
        {
            activeRay.SetPosition(1, hit[j].point);
            Entity entity = hit[j].collider.GetComponent<Entity>();

            if (entity != null)
            {
                entity.ReceiveDamage(model.PenetrationDamage.Value);
                model.PenetrationDamage.Value -= entity.PenetrationDamageReduction;

                if (hit[j].rigidbody != null)
                {
                    hit[j].rigidbody.AddForce(-hit[j].normal * model.BulletForce.Value);
                }

                if (model.PenetrationDamage.Value <= 0 || model.BulletPenetration.Value <= 0)
                    break;
            }
        }
    }

    public void ResetTriggerTime()
    {
        model.TriggerTimer.Value = 0f;
    }
}
