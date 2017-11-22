using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Wymagania:
// Skrypt podłączamy oczywiście do obiektu gracza.
// Gracz musi mieć komponent RigidBody 2D i jakiś collider, ja mam box.
// Platforma, podłoże czy jak to tam nazwać też musi mieć collider.
// Pola publiczne do zmiany w inspectorze, dokładne wartości zależą oczywiście od preferencji, skali mapy itp,
// dla mnie ładnie działało acc = 30, maxvel = 30, i howmuchfaster... = 2.
// Polecam też zmienić w rigidbody linear drag na coś koło 1,5 coby się ładnie hamowało gdy nie ma inputu.

// Zmiany:
// - mała zmiana logiki ruchu w x
// - dodane "granice przyspieszenia" w celu upłynnienia ruchu
public class PlayerController : MonoBehaviour
{
    /// <summary>
    /// Wartość przyspieszenia (o ile poziomy input przyspiesza).
    /// </summary>
    public float Acceleration;
    /// <summary>
    /// Maksymalna prędkość, jaką obiekt może osiągnąć.
    /// </summary>
    public float MaxVelocity;
    /// <summary>
    /// Ile razy szybciej obiekt zmienia kierunek niż przyspiesza.
    /// </summary>
    public float HowMuchFasterIsChangingDirection;
    /// <summary>
    /// Po jakiej części (w procentach) MaxVelocity przyspieszenie zostaje zmniejszone. (możliwe dodatkowe granice kiedyś)
    /// </summary>
    public float AccelerationCutThresholdPercent;
    /// <summary>
    /// Jaki procent przyspiesznia "zostaje" po przekroczeniu pewnej granicy (AccelerationCutThreshold) (w celu "upłynnienia" ruchu).
    /// </summary>
    public float AccelerationPercentAfterThreshold;

    private Rigidbody2D rb;


	void Start()
    {
        rb = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate()
    {
        Move();
	}

    /// <summary>
    /// Odpowiada za poruszanie obiektem.
    /// </summary>
    void Move()
    {
        // Ustala wektor siły, jaka będzie dodana - zależna od inputu.
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector2 horizontalMovement = new Vector2(moveHorizontal, 0);

        // Sprawdza (poprzez porównanie znaków inputu i aktualnej prędkości), czy gracz próbuje przyspieszyć, czy zmienić kierunek.
        // Jeśli zmienia kierunek (tj, znaki są różne), działamy z większą siłą - chcemy aby zmiana była szybsza niż przyspieszanie.
        if ((rb.velocity.x >= 0 && horizontalMovement.x <= 0) || (rb.velocity.x <= 0 && horizontalMovement.x >= 0))
        {
            rb.AddForce(horizontalMovement * Acceleration * HowMuchFasterIsChangingDirection);
        }
        // W innym wypadku przyspieszamy normalnie - ale tylko jeśli aktualna prędkość nie przekracza odpowiedniej części max.
        else if (rb.velocity.magnitude <= MaxVelocity * (AccelerationCutThresholdPercent / 100))
        {
            rb.AddForce(horizontalMovement * Acceleration);
        }
        // Jeśli przekracza tę część - przypieszamy mniej gwałtownie.
        else if (rb.velocity.magnitude <= MaxVelocity)
        {
            rb.AddForce(horizontalMovement * Acceleration * (AccelerationPercentAfterThreshold / 100));
        }
    }
}
