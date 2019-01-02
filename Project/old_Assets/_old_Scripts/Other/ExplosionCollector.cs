using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Destroys the explosion object after explosion.

public class ExplosionCollector : MonoBehaviour {

    private float lifespan;

	void Awake()
    {
        lifespan = GetComponent<ParticleSystem>().main.duration;
	}
	
	void Update()
    {
        lifespan -= Time.deltaTime;
		if (lifespan <= 0f)
        {
            Destroy(gameObject);
        }
	}
}
