using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    PlayerController player;
    Image image;
    Text ammoText;

    void SetHUD()
    {
        Transform hptrans = transform.Find("HP");
        image = hptrans.GetComponent<Image>();
        image.type = Image.Type.Filled;
        image.fillMethod = Image.FillMethod.Vertical;
        image.fillOrigin = (int)Image.OriginVertical.Bottom;
        //Debug.Log((Image.OriginVertical)image.fillOrigin);

        Transform ammotrans = transform.Find("Ammo");
        ammoText = ammotrans.GetComponent<Text>();
    }
    void Start()
    {
        SetHUD();
    }

    void Update()
    {
        image.fillAmount = hp / maxHp;

        ammoText.text = ammo.ToString();
    }
}
