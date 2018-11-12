using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyArena : MonoBehaviour
{
    Vector2 reflectionForce;
    [SerializeField] private float reflectionPower=5;
    void OnCollisionEnter2D(Collision2D collider)
    {
        Debug.Log("WAT");
        if (collider.otherCollider.GetType() == typeof(CapsuleCollider2D))
        { }
            reflectionForce = collider.transform.GetComponent<Rigidbody2D>().velocity;
            reflectionForce =(transform.rotation * Vector2.up) * reflectionPower * reflectionForce.y;
            collider.transform.GetComponent<Rigidbody2D>().AddForce(reflectionForce, ForceMode2D.Impulse);
        
    }

    IEnumerator Spring()
    {
        for (int i = 0; i < 30; i++)
        {


            yield return null;
        }
        
    }
    IEnumerator Launch()
    {
        for (int i = 0; i < 10; i++)
        {



            yield return null;
        }
    }

    void OndrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(Vector2.zero, Vector2.up * 5);
        Gizmos.DrawLine(transform.position, transform.position + (transform.rotation * Vector2.up * 5));
    }
}
