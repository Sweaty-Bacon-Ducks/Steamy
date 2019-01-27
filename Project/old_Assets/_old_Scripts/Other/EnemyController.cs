using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    Transform player;               // Reference to the player's position.
    //PlayerHealth playerHealth;      // Reference to the player's health.
    //EnemyHealth enemyHealth;        // Reference to this enemy's health.
    float hp = 500;
    // Use this for initialization
    void Start()
    {

    }

    private void OnParticleCollision(GameObject other)
    {
        hp -= 1;
        Debug.Log("hit");
    }

    //void OnParticleTrigger()
    //{
    //    HP -= 1;
    //    Debug.Log("hit");
    //}

    // Update is called once per frame
    void Update()
    {

    }

}
