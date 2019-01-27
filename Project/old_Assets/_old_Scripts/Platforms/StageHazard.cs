using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum direction { North, NorthEast,East,SouthEast,South,SouthWest, NorthWest,West}
public class StageHazard : MonoBehaviour
{
    [SerializeField] private bool active= true;
    [SerializeField] private float damageValue = 10f;
    [SerializeField] private float fallbackForce = 10;
    [SerializeField] private direction pushDiredtion = direction.North;
    private Vector2 fallback;

    void OnCollisionEnter2D(Collision2D collider)
    {
        Debug.Log("Hi");
        Debug.Log(transform.gameObject.layer);
        

        if (active && collider.gameObject.layer != 10)
        {
            collider.transform.GetComponent<Player>().Rpc_TakeDamage(null, damageValue);

            switch (pushDiredtion)
            {
                case direction.North:
                    fallback = new Vector2(0, 1);
                    break;
                case direction.NorthEast:
                    fallback = new Vector2(1, 1);
                    break;
                case direction.East:
                    fallback = new Vector2(1,0);
                    break;
                case direction.SouthEast:
                    fallback = new Vector2(1, -1);
                    break;
                case direction.South:
                    fallback = new Vector2(0, -1);
                    break;
                case direction.SouthWest:
                    fallback = new Vector2(-1, -1);
                    break;
                case direction.West:
                    fallback = new Vector2(1,0);
                    break;
                case direction.NorthWest:
                    fallback = new Vector2(-1, 1);
                    break;
            }


            fallback = fallback * fallbackForce;
            Debug.Log(fallback);
            
            collider.transform.GetComponent<Rigidbody2D>().AddForce(fallback, ForceMode2D.Impulse);
        }
    }
    void Update()
    {
        Debug.DrawLine(transform.position, transform.localRotation*(transform.position + Vector3.up*fallbackForce));
    }

}
