using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCollisionDetector : MonoBehaviour 
{
    private string GroundedAnimatorVariable = "isGrounded";
    public Animator animator;
	
	void Start () 
    {
        Animator animator = GetComponent<Animator>();
	}
	
	void Update () 
    {
		
	}

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name == "Ground1" || collision.gameObject.name == "Ground2")
        {
            animator.SetBool(GroundedAnimatorVariable, true);
        }
    }
 
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Ground1" || collision.gameObject.name == "Ground2")
        {
            animator.SetBool(GroundedAnimatorVariable, false);
        }
    }
}
