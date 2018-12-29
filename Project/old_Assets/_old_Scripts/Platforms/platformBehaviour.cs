using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum behaviourStyle {byDistance, byReflect }
public class platformBehaviour : MonoBehaviour
{

    [SerializeField] private behaviourStyle movementStyle = behaviourStyle.byReflect;
    [SerializeField] private bool platformMovement = false;
    [SerializeField] private float maxDistance = 10;
    private float acumulatedDistance = 0;
    Vector3 movementDirection=new Vector3(1, 0, 0);
    [SerializeField] private float movementSpeed = 1f;
    Vector3 movement;
    

   
	


	
	void Update ()
    {
        if (platformMovement)
        {
            movement = movementDirection * movementSpeed * Time.deltaTime;
            transform.position += movement;
           
            if (movementStyle==behaviourStyle.byDistance)
            {
                
                acumulatedDistance += movement.x;
                
               if( Mathf.Abs(acumulatedDistance)>=maxDistance)
                {
                    Debug.Log(Mathf.Abs(acumulatedDistance));
                    movementDirection *= -1;
                    acumulatedDistance = 0;
                }
               

            }
            
        }
		
	}
    void OnCollisionEnter2D(Collision2D collider)
    {
        
        if (collider.gameObject.layer==10)
        {
            if (movementStyle == behaviourStyle.byReflect)
            {
                movementDirection *= -1;
            }
            
        }
        else
        {
            collider.transform.SetParent(transform);
        }
    }
    void OnCollisionExit2D(Collision2D collider)
    {
        if (collider.gameObject.layer!=10)
        {           
                collider.transform.parent = null;                      
        }        
    }

    
}
