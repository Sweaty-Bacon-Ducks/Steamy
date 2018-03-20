using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    Transform player;               // Reference to the player's position.
    //PlayerHealth playerHealth;      // Reference to the player's health.
    //EnemyHealth enemyHealth;        // Reference to this enemy's health.
    //NavMeshAgent nav;               // Reference to the nav mesh agent.
    float hp = 500;
    // Use this for initialization
    void Start()
    {

    }

    void Awake()
    {
        // Set up the references.
        //player = GameObject.FindGameObjectWithTag("Player").transform;
        //playerHealth = player.GetComponent<PlayerHealth>();
        //enemyHealth = GetComponent<EnemyHealth>();
        //nav = GetComponent<NavMeshAgent>();
    }

    private void OnParticleCollision(GameObject other)
    {
        hp -= 1;
        Debug.Log("hit");
    }

    // Update is called once per frame
    void Update()
    {
        // If the enemy and the player have health left...
        //if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
        //{
        // ... set the destination of the nav mesh agent to the player.
        //      nav.SetDestination(player.position);
        //}
        // Otherwise...
        //else
        //{
        // ... disable the nav mesh agent.
        //nav.enabled = false;
        //}
    }

}
