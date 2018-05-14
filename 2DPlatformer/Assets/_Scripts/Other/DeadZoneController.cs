using Platformer;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class DeadZoneController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player;
        if (player = collision.GetComponent<PlayerController>())
        {
            StartCoroutine(player.Respawn());
        }
    }
}
