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

    private Rigidbody2D rb;

	void Start()
    {
        rb = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate()
    {
        // Ustala wektor siły, jaka będzie dodana - zależna od inputu.
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector2 horizontalMovement = new Vector2(moveHorizontal, 0);

        if (rb.velocity.magnitude <= MaxVelocity)
        {
            // Sprawdza (poprzez porównanie znaków inputu i aktualnej prędkości), czy gracz próbuje przyspieszyć, czy zmienić kierunek.
            // Jeśli przyspiesza, dodajemy standardową siłę.
            if ((rb.velocity.x >= 0 && horizontalMovement.x >= 0) || (rb.velocity.x <= 0 && horizontalMovement.x <= 0))
            {
                rb.AddForce(horizontalMovement * Acceleration);
            }
            // W innym wypadku działamy większą siłą - chcemy, aby zmiana kierunku była szybsza.
            else
            {
                rb.AddForce(horizontalMovement * Acceleration * HowMuchFasterIsChangingDirection);
            }
        }
	}
}
