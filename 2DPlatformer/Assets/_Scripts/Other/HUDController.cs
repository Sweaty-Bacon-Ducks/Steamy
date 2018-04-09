using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    private PlayerController player;

    public Image image;
    public Text ammoText;

    void Start()
    {
        SetHUD();
    }

    void Awake()
    {
        player = transform.root.GetComponent<PlayerController>();
    }

    void Update()
    {
        image.fillAmount = player.info.HP / player.info.MaxHP;
        ammoText.text = player.info.CurrentWeapon.CurrentAmmo.ToString();
    }

    void SetHUD()
    {
        image.fillAmount = 1;
        ammoText.text = player.info.CurrentWeapon.CurrentAmmo.ToString() + "/" + player.info.CurrentWeapon.MaxAmmo.ToString();
    }
}
