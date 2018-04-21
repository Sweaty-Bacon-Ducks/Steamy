using UnityEngine;
using UnityEngine.UI;

namespace Platformer
{
    public class HUDController : MonoBehaviour
    {
        private PlayerController player;

        public Image image;
        public Text ammoText;
        public Image weaponSprite;
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
            ammoText.text = player.info.CurrentWeapon.CurrentAmmo.ToString() + "/" + player.info.CurrentWeapon.MaxAmmo.ToString();
        }

        void SetHUD()
        {
            weaponSprite.sprite = player.info.CurrentWeapon.GUISprite;
            image.fillAmount = 1;
            ammoText.text = player.info.CurrentWeapon.CurrentAmmo.ToString() + "/" + player.info.CurrentWeapon.MaxAmmo.ToString();
            Debug.Log(ammoText.text);
        }
    }
}