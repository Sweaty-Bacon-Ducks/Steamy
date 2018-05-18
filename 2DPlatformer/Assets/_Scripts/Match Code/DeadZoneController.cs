using Platformer;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class DeadZoneController : MonoBehaviour
{
    private const float PLAYER_INSTANT_KILL = 10000f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player;
        if (player = collision.GetComponent<Player>())
        {
            player.Rpc_TakeDamage(PLAYER_INSTANT_KILL);
        }
    }
}
