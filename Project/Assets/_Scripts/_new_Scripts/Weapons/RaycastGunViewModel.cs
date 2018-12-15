using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastGunViewModel : WeaponViewModel
{
    // Wpadlem na pomysl zmiennej HitForce. Kazde entity bedzie ja mialo i pozwoli to na penetracje
    // sztucznie przypisac czas przeladowania jak bedziemy znali dlugosc animacji
    public Transform ProjectileSpawn;
    public GameObject LineRendererPrefab;

    private Vector3 RayDirection;

    private int BulletsInMagazine;
    private float FireTimer = 0f;
    private float TriggerTimer = 0f;
    
    public RaycastGunModel RaycastGunModel;
    private LineRenderer activeRay;

    public float PenDamage;
    public float PenLeft;

    [SerializeField]
    private bool reloading = false;

    private void Start()
    {
        BulletsInMagazine = RaycastGunModel.MagazineSize;
    }

    private void Update() //TMP dopóki nie ustalimy gdzie input powinien być
    {
        if (Input.GetButton("Fire1"))
        {
            AttackTry();
        }
        if (Input.GetButtonUp("Fire1"))
        {
            TriggerTimer = 0f;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            ReloadTry();
        }
    }

    public void AttackTry()
    {
        TriggerTimer += Time.deltaTime;
        if (Time.time > FireTimer && BulletsInMagazine >= 1 && reloading == false  && TriggerTimer >= RaycastGunModel.TimeToFire)
        {
            FireTimer = Time.time + RaycastGunModel.FireRate;

            Attack();
        }
    }

    private IEnumerator ShotEffect()
    {
        activeRay = Instantiate(LineRendererPrefab).GetComponent<LineRenderer>();
        LineRenderer newRay = activeRay;
        yield return new WaitForSeconds(RaycastGunModel.ShotDuration);
        Destroy(newRay.gameObject);
    }


    public void ReloadTry()
    {
        if (BulletsInMagazine < RaycastGunModel.MagazineSize && reloading == false)
        {
            StartCoroutine(Reload());
        }
    }

    private IEnumerator Reload()
    {
        reloading = true;
        yield return new WaitForSeconds(RaycastGunModel.ReloadTime);
        reloading = false;
        BulletsInMagazine = RaycastGunModel.MagazineSize;
    }

    public override void Attack()
    {
        --BulletsInMagazine;

        for (int i = 0; i < RaycastGunModel.BulletCount; ++i)
        {
            PenDamage = RaycastGunModel.Damage;
            PenLeft = RaycastGunModel.BulletPenetration;

            StartCoroutine(ShotEffect());

            Vector3 rayOrigin = ProjectileSpawn.position;

            //
            Vector3 TMPPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            TMPPos.z = 0;
            //

            Vector3 direction = ProjectileSpawn.right; // Bullet Spread
            direction.y += Random.Range(-RaycastGunModel.BulletSpread, RaycastGunModel.BulletSpread);

            activeRay.SetPosition(0, rayOrigin);

            RaycastHit[] hit;
            hit = Physics.RaycastAll(rayOrigin, direction, RaycastGunModel.RaycastLength);
            if (hit.Length > 0)
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
            else
            {
                activeRay.SetPosition(1, rayOrigin + (direction * RaycastGunModel.RaycastLength));
            }
        }
    }
}
