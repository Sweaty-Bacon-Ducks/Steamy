using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffZone : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    [SerializeField] private Buff effect;
    [SerializeField] private bool platformEffect = false;
    [SerializeField] private int cooldownTime = 5;

    // Update is called once per frame
    void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D collider)
    {
        Player pc = collider.transform.GetComponent<Player>();
        if (pc != null)
        {
            if (platformEffect)
            {
                collider.transform.GetComponent<Player>().Subscribe(effect);
                StartCoroutine(Cooldown());
            }

        }
        
    }

    IEnumerator Cooldown()
    {
        platformEffect = false;

        yield return new WaitForSeconds(cooldownTime);

        platformEffect = true;
    }
}
