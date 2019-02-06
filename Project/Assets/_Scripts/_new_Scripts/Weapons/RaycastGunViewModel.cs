using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Steamy.Weapons
{
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

        public override void Attack()
        {
            model.ShotChargeTimer += Time.deltaTime;
            if (CanAttack())
            {
                model.FireTimer = Time.time + model.FireRate;

                ExecuteAttack();
            }
        }

        private bool CanAttack()
        {
            // There are bullets in magazine and player is not reloading already
            if (model.BulletsInMagazine >= 1 && model.Reloading == false)
            {
                // Not waiting for shot to charge and firerate timer
                if (model.ShotChargeTimer >= model.ShotChargeTime && Time.time > model.FireTimer)
                {
                    return true;
                }
            }
            return false;
        }

        public override void StopAttack()
        {
            model.ShotChargeTimer = 0f;
        }

        /// <summary>
        /// Function called on pressing the ReloadButton
        /// </summary>
        public override void Reload()
        {
            if (model.BulletsInMagazine < model.MagazineSize && model.Reloading == false)
            {
                StartCoroutine(ExecuteReload());
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

        private IEnumerator ExecuteReload()
        {
            model.Reloading = true;
            yield return new WaitForSeconds(model.ReloadTime);
            model.Reloading = false;
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
}

