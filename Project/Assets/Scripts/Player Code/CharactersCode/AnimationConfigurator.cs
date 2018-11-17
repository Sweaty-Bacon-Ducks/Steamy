using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationConfigurator : MonoBehaviour
{
    Animator animator;
    float speedPercent;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }


    void Update()
    {
        speedPercent = animator.GetFloat("speedPercent");
        if (speedPercent < 1)
        {
            animator.SetFloat("speedPercent", speedPercent + 0.005f, .1f, Time.deltaTime);
        }
    }
}
