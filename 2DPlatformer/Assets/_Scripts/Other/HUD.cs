using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

//[RequireComponent(typeof(Image))]
public class HUD : MonoBehaviour
{
    float maxHp = 100;
    [Range(0,100)]
    public float hp = 50;
    //public Image obrazek;
    Image image;
    Text ammoText;

    public int ammo = 0;
    // Use this for initialization
    void Start()
    {
        //foreach (Transform child in transform)
        //{
        //    child.position += Vector3.up * 10.0F;
        //}
        //Transform hptrans = transform.GetChild(0);
        Transform hptrans = transform.Find("HP");
        image = hptrans.GetComponent<Image>();
        //image = GetComponentInChildren<Image>();
        image.type = Image.Type.Filled;
        image.fillMethod = Image.FillMethod.Vertical;
        image.fillOrigin = (int)Image.OriginVertical.Bottom;
        Debug.Log((Image.OriginVertical)image.fillOrigin);
        

        Transform ammotrans = transform.Find("Ammo");

        ammoText = ammotrans.GetComponent<Text>();
    }

    //public static List<GameObject> Initialize(Transform player)
    //{
    //    foreach (Transform tr in player)
    //    {
    //        if (tr != player.root && !AllWeapons.Contains(tr.gameObject))
    //        {
    //            AllWeapons.Add(tr.gameObject);
    //        }
    //    }
    //    return AllWeapons;
    //}


    // Update is called once per frame
    void Update()
    {
        image.fillAmount = hp / maxHp;

        ammoText.text = ammo.ToString();
    }
}
