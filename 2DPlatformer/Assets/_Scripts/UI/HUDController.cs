using UnityEngine;
using UnityEngine.UI;

namespace Platformer
{
    public class HUDController : MonoBehaviour
    {
        private Player player;

        public Image image;
        public Text ammoText;
        public Image weaponSprite;
        void Start()
        {
            SetHUD();
        }

        void Awake()
        {
            player = transform.root.GetComponent<Player>();
        }

        void Update()
        {
            image.fillAmount = player.HP / player.MaxHP;
            ammoText.text = player.info.CurrentWeapon.CurrentAmmo.ToString() + "/" + player.info.CurrentWeapon.MaxAmmo.ToString();
        }

        void SetHUD()
        {
            image.fillAmount = 1;
            ammoText.text = player.info.CurrentWeapon.CurrentAmmo.ToString() + "/" + player.info.CurrentWeapon.MaxAmmo.ToString();
            //Debug.Log(ammoText.text);
        }
    }
}