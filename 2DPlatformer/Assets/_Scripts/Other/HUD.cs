using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
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
        image.fillAmount = player.HP / player.MaxHP;
        ammoText.text = player.CurrentWeapon.CurrentAmmo.ToString();
    }

    void SetHUD()
    {
        image.fillAmount = 1;
        //ammoText.text = player.CurrentWeapon.CurrentAmmo.ToString() + "/" + player.CurrentWeapon.MaxAmmo.ToString();
    }
}
