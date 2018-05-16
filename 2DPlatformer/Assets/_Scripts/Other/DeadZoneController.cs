using Platformer;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class DeadZoneController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player;
        if (player = collision.GetComponent<Player>())
        {
            StartCoroutine(player.Respawn());
        }
    }
}
