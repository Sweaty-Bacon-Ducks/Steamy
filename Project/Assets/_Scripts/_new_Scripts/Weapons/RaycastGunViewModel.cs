using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastGunViewModel : WeaponViewModel
{
    public RaycastGunModel RaycastGunModel;
    public Transform ProjectileSpawn;
    public GameObject LineRendererPrefab;

    private Vector3 RayDirection;

    private int BulletsInMagazine;
    private float FireTimer = 0f; // Must be >= FireRate if gun fires full auto
    private float TriggerTimer = 0f; // Time between mouse click and first shot in sequence

    private LineRenderer activeRay;

    private float PenDamage; // How much damage does bullet after penetrating
    private float PenLeft; // How much penetration is left before stopping the bullet

    private bool reloading = false;

    private void Start()
    {
        BulletsInMagazine = RaycastGunModel.MagazineSize;
    }

    private void Update() //TMP dopóki nie ustalimy gdzie input powinien być
    {
        if (Input.GetButton("Fire1"))
        {
            Attack();
        }

        if (Input.GetButtonUp("Fire1"))
        {
            TriggerTimer = 0f;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }

    public override void Attack()
    {
        TriggerTimer += Time.deltaTime;
        if (Time.time > FireTimer && BulletsInMagazine >= 1 && reloading == false && TriggerTimer >= RaycastGunModel.TimeToFire)
        {
            FireTimer = Time.time + RaycastGunModel.FireRate;

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
        yield return new WaitForSeconds(RaycastGunModel.ShotDuration);
        Destroy(newRay.gameObject);
    }

    /// <summary>
    /// Function called on pressing the ReloadButton
    /// </summary>
    public void Reload()
    {
        if (BulletsInMagazine < RaycastGunModel.MagazineSize && reloading == false)
        {
            StartCoroutine(ExecuteReload());
        }
    }

    private IEnumerator ExecuteReload()
    {
        reloading = true;
        yield return new WaitForSeconds(RaycastGunModel.ReloadTime);
        reloading = false;
        BulletsInMagazine = RaycastGunModel.MagazineSize;
    }

    private void ExecuteAttack()
    {
        --BulletsInMagazine;

        for (int i = 0; i < RaycastGunModel.BulletCount; ++i)
        {
            PenDamage = RaycastGunModel.Damage;
            PenLeft = RaycastGunModel.BulletPenetration;

            StartCoroutine(ShotEffect());

            //
            Vector3 TMPPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            TMPPos.z = 0;
            //

            Vector3 direction = ProjectileSpawn.right;
            direction.y += Random.Range(-RaycastGunModel.BulletSpread, RaycastGunModel.BulletSpread); // Creating bullet spread

            Vector3 rayOrigin = ProjectileSpawn.position;
            activeRay.SetPosition(0, rayOrigin);

            // Save every object on ray path
            RaycastHit[] hit;
            hit = Physics.RaycastAll(rayOrigin, direction, RaycastGunModel.RaycastLength);
            if (hit.Length > 0)
            {
                ShootOneRay(hit);
            }
            else
            {
                activeRay.SetPosition(1, rayOrigin + (direction * RaycastGunModel.RaycastLength));
            }
        }
    }

    private void ShootOneRay(RaycastHit[] hit)
    {
        for (int j = 0; j < hit.Length; ++j)
        {
            activeRay.SetPosition(1, hit[j].point);
            Entity entity = hit[j].collider.GetComponent<Entity>();

            if (entity != null)
            {
                entity.ReceiveDamage(PenDamage);
                PenDamage -= entity.PenetrationDamageReduction;

                if (hit[j].rigidbody != null)
                {
                    hit[j].rigidbody.AddForce(-hit[j].normal * RaycastGunModel.BulletForce);
                }

                if (PenDamage <= 0 || RaycastGunModel.BulletPenetration <= 0)
                    break;
            }
        }
    }
}
