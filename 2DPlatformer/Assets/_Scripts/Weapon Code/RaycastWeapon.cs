using System;
using UnityEngine;

public class RaycastWeapon : Weapon
{
    public override void Shoot(Vector3 start, Vector3 end)
    {
        float distance = Mathf.Infinity;//jaka dlugosc
        int layerMask = Physics.DefaultRaycastLayers;//dobrac layer
        float maxDepth = Mathf.Infinity;
        RaycastHit2D hit = Physics2D.Raycast(start, end - start, distance, layerMask, 0, maxDepth);
        //if (hit.transform.tag == "Player")
        //    Debug.Log("bum  w " + hit);
    }
}