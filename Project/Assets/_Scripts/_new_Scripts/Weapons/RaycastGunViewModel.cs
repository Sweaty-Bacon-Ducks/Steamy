using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastGunViewModel : WeaponViewModel
{
    private RaycastGunModel model;

    public RaycastGunDefault SO;
    public Transform ProjectileSpawn;
    public GameObject LineRendererPrefab;

    private Vector3 rayDirection;
    private LineRenderer activeRay;

    private void Start()
    {
        model = new RaycastGunModel(this, SO);
    }

    private void Update() //TMP dopóki nie ustalimy gdzie input powinien być
    {
        if (Input.GetButton("Fire1"))
        {
            Attack();
        }

        if (Input.GetButtonUp("Fire1"))
        {
            model.TriggerTimer = 0f;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }

    public override void Attack()
    {
        model.TriggerTimer += Time.deltaTime;
        if (Time.time > model.FireTimer && model.BulletsInMagazine >= 1 && model.reloading == false && model.TriggerTimer >= model.TimeToFire)
        {
            model.FireTimer = Time.time + model.FireRate;

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
        yield return new WaitForSeconds(model.ShotDuration);
        Destroy(newRay.gameObject);
    }

    /// <summary>
    /// Function called on pressing the ReloadButton
    /// </summary>
    public void Reload()
    {
        if (model.BulletsInMagazine < model.MagazineSize && model.reloading == false)
        {
            StartCoroutine(ExecuteReload());
        }
    }

    private IEnumerator ExecuteReload()
    {
        model.reloading = true;
        yield return new WaitForSeconds(model.ReloadTime);
        model.reloading = false;
        model.BulletsInMagazine = model.MagazineSize;
    }

    private void ExecuteAttack()
    {
        model.BulletsInMagazine--;

        for (int i = 0; i < model.BulletCount; ++i)
        {
            model.PenetrationDamage = model.Damage;
            model.PenetrationLeft = model.BulletPenetration;

            StartCoroutine(ShotEffect());

            Vector3 direction = ProjectileSpawn.right;
            direction.y += Random.Range(-model.BulletSpread, model.BulletSpread); // Creating bullet spread

            Vector3 rayOrigin = ProjectileSpawn.position;
            activeRay.SetPosition(0, rayOrigin);

            // Save every object on the ray's path and iterate over them to check how many were penetrated and damaged
            RaycastHit[] hit;
            hit = Physics.RaycastAll(rayOrigin, direction, model.RaycastLength);
            if (hit.Length > 0)
            {
                ShootOneRay(hit);
            }
            else
            {
                activeRay.SetPosition(1, rayOrigin + (direction * model.RaycastLength));
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
                entity.ReceiveDamage(model.PenetrationDamage);
                model.PenetrationDamage -= entity.PenetrationDamageReduction;

                if (hit[j].rigidbody != null)
                {
                    hit[j].rigidbody.AddForce(-hit[j].normal * model.BulletForce);
                }

                if (model.PenetrationDamage <= 0 || model.BulletPenetration <= 0)
                    break;
            }
        }
    }
}
