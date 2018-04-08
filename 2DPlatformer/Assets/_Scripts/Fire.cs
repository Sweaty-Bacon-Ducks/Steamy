using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public ParticleSystem flame;

    public float maxAmmo = 50f;
    public float currentAmmo;
    public float reloadTime = 1f;
    private bool isReloading = false;

    // Use this for initialization
    void Start()
    {
        flame.Stop();
        currentAmmo = maxAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        if (isReloading)
        {
            return;
        }

        if (currentAmmo <= 0)
        {
            flame.Stop();
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetButton("Fire1"))
        {
            flame.Play();
            currentAmmo--;
        }
        else
        {
            flame.Stop();
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("reloading weapon");

        yield return new WaitForSeconds(reloadTime);

        currentAmmo = maxAmmo;

        isReloading = false;
    }
}
