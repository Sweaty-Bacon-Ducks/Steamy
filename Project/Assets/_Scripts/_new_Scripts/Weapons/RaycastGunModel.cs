using UnityEngine;

public class RaycastGunModel : WeaponModel
{
    #region From ScriptableObject
    public float BulletSpread;
    public int BulletCount;
    public int MagazineSize;
    public float FireRate;
    public float BulletPenetration;
    public float BulletForce;
    public float ReloadTime;
    [Tooltip("Time between mouse click and the first shot.\n" +
             "Consecutive shots are not affected.\n" +
             "Resets after releasing left mouse button.")]
    public float TimeToFire;
    #endregion

    #region Raycast unique
    public float RaycastLength;
    public float ShotDuration;
    #endregion

    #region Frequently changing
    public int BulletsInMagazine;
    [Tooltip("Must be >= FireRate if gun fires full auto")]
    public float FireTimer = 0f;
    [Tooltip("Time between mouse click and first shot in sequence")]
    public float TriggerTimer = 0f;
    [Tooltip("How much damage does the bullet after penetrating\n" +
         "the latest obstacle")]
    public float PenetrationDamage;
    [Tooltip("How much penetration is left before the bullet stops")]
    public float PenetrationLeft;
    public bool reloading = false;
    #endregion

    public RaycastGunViewModel ViewModel;


    public RaycastGunModel(RaycastGunViewModel viewModel, RaycastGunDefault SO)
    {
        LoadFromScriptableObject(viewModel, SO);
    }

    public void LoadFromScriptableObject(RaycastGunViewModel viewModel, RaycastGunDefault SO)
    {
        this.Name = SO.Name;
        this.Desc = SO.Desc;
        this.Sprite = SO.Sprite;
        this.Damage = SO.Damage;

        this.BulletSpread = SO.BulletSpread;
        this.BulletCount = SO.BulletCount;
        this.MagazineSize = SO.MagazineSize;
        this.FireRate = SO.FireRate;
        this.BulletPenetration = SO.BulletPenetration;
        this.BulletForce = SO.BulletForce;
        this.ReloadTime = SO.ReloadTime;
        this.TimeToFire = SO.TimeToFire;
        this.RaycastLength = SO.RaycastLength;
        this.ShotDuration = SO.ShotDuration;
        this.ViewModel = viewModel;

        this.BulletsInMagazine = SO.MagazineSize;
    }
}
