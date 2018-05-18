using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class FireballController : NetworkBehaviour
{
    private const string PLAYER_TAG = "Player";

    public float Damage = 10f;
    public float LifeTime = 3f;

    private void OnEnable()
    {
        StartCoroutine(DestroyAfterSeconds(LifeTime));
    }

    private IEnumerator DestroyAfterSeconds(float seconds)
    {
        float currentTime = LifeTime;
        do
        {
            currentTime -= Time.deltaTime;
            yield return null;
        } while (currentTime > 0);
        NetworkServer.Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(PLAYER_TAG))
        {
            StopCoroutine(DestroyAfterSeconds(LifeTime));
            string _playerID = collision.transform.name;
            collision.gameObject.GetComponent<Player>().Cmd_PlayerShot(_playerID,Damage);
            NetworkServer.Destroy(gameObject);
        }   
    }
}
