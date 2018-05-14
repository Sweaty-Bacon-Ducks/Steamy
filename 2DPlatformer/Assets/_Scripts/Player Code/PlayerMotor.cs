using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Przechowuje wszelkie funkcje związane z ruchem gracza na scenie
/// </summary>
public class PlayerMotor : MonoBehaviour
{
    /// <summary>
    /// Nadaje graczowi prędkość.
    /// </summary>
    /// <param name="info">Obiekt zawierający informacje o graczu</param>
    public void Move(PlayerInfo info)
    {
        // Czy jest potrzebne zarówno IsMoving i IsStanding?
        if (info.Body.velocity.x == 0 && info.Body.velocity.y == 0)
        {
            info.IsMoving = false;
            info.IsStanding = true;
        }
        else
        {
            info.IsMoving = true;
            info.IsStanding = false;
        }

        float moveHorizontal = Input.GetAxis("Horizontal");
        // Body.velocity, bo w ten sposób ruch jest dużo bardziej responsywny.
        info.Body.velocity = new Vector2(moveHorizontal * info.Speed, info.Body.velocity.y);
        info.AnimationController.SetBool("IsRunning",info.IsMoving);
    }
    /// <summary>
    /// Zwiększa aktualną prędkość gracza o pewien ustalony mnożnik.
    /// </summary>
    /// <param name="info">Obiekt zawierający informacje o graczu</param>
    public void Sprint(PlayerInfo info)
    {
        // Sprint działa tylko gdy jest wciśnięty jakiś klawisz ruchu i nie w powietrzu.
        if (info.IsGrounded == false && Input.GetAxis("Horizontal") != 0)
        {
            info.Body.velocity = new Vector2(info.Body.velocity.x * info.SprintMult, info.Body.velocity.y);
        }
    }
    /// <summary>
    /// Nadaje graczowi prędkość na osi Y.
    /// </summary>
    /// <param name="info">Obiekt zawierający informacje o graczu</param>
    public void Jump(PlayerInfo info)
    {
        // Na razie bez double jump.
        if (info.IsGrounded == false)
        {
            Vector2 jump = new Vector2(0, info.JumpForce);
            info.Body.AddForce(jump, ForceMode2D.Impulse);
        }
    }
}
