using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationConfigurator : MonoBehaviour
{
    Animator animator;
    Camera cam;
    
    float y;
    float targetY;
    float remainingY;
    bool isFacingRight;
    float rotationSpeed;
    float deltaTime;
    Vector3 headDir;
    Vector3 headPosition;
    float headAngle;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        cam = GameObject.Find("Camera").GetComponent<Camera>();
        y = 0.0f;
        rotationSpeed = 700.0f;
    }


    void Update()
    {
        deltaTime = Time.deltaTime;
        isFacingRight = animator.GetBool("isFacingRight");
        headPosition = cam.WorldToScreenPoint(animator.GetBoneTransform(HumanBodyBones.Head).position);
        headDir = cam.WorldToScreenPoint(headPosition - Input.mousePosition);
        headAngle = Vector3.Angle(headDir, transform.up * -1.0f);

        if (Input.mousePosition.x - 20.0f >= headPosition.x)
        {
            animator.SetFloat("headTiltPercent", (headAngle - 20.0f) / 180.0f);
        }

        if (Input.mousePosition.x - 50.0f >= headPosition.x && isFacingRight == false)
        {
            animator.SetBool("isFacingRight", true);  
        }

        if (Input.mousePosition.x + 20.0f <= headPosition.x)
        {
            animator.SetFloat("headTiltPercent", (200.0f - headAngle) / 180.0f);
        }

        if (Input.mousePosition.x + 50.0f <= headPosition.x && isFacingRight == true)
        {
            animator.SetBool("isFacingRight", false); 
        }

        if (isFacingRight) targetY = 0.0f;
        else targetY = 180.0f;

        if (y != targetY && remainingY == 0)
        {
            remainingY += 180.0f;
        }

        if (remainingY > 0)
        {
            if (remainingY <= deltaTime * rotationSpeed)
            {
                if (y < 180.0f) y = 180.0f;
                else y = 0.0f;
                remainingY = 0.0f;

                if (y >= 360.0f)
                {
                    y -= 360.0f;
                }
            }
            else if (y != targetY)
            {
                y += deltaTime * rotationSpeed;
                remainingY -= deltaTime * rotationSpeed;

                if (y >= 360.0f)
                {
                    y -= 360.0f;
                }

            }

        }

        transform.localRotation = Quaternion.Euler(0, y, 0);
    

    }
}