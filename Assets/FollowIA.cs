using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowIA : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float minDistance;         // Distancia para atacar
    [SerializeField] private float rangoDeteccion;      // Radio para empezar a seguir
    [SerializeField] private Transform Player;

    private bool isFacingRight = true;
    private Vector3 posicionInicial;

    void Start()
    {
        posicionInicial = transform.position;
    }

    void Update()
    {
        float distanciaAlJugador = Vector2.Distance(transform.position, Player.position);

        if (distanciaAlJugador <= rangoDeteccion)
        {
            if (distanciaAlJugador > minDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, Player.position, speed * Time.deltaTime);
            }
            else
            {
                Attack();
            }

            bool isPlayerRight = transform.position.x < Player.transform.position.x;
            Flip(isPlayerRight);
        }
        else
        {
            // Regresar a la posición inicial si el jugador está fuera del rango
            if (Vector2.Distance(transform.position, posicionInicial) > 0.1f)
            {
                transform.position = Vector2.MoveTowards(transform.position, posicionInicial, speed * Time.deltaTime);

                // Ajustar dirección mientras regresa
                bool isGoingRight = transform.position.x < posicionInicial.x;
                Flip(isGoingRight);
            }
        }
    }

    private void Attack()
    {
        Debug.Log("Atacar");
    }

    private void Flip(bool isPlayerRight)
    {
        if ((isFacingRight && !isPlayerRight) || (!isFacingRight && isPlayerRight))
        {
            isFacingRight = !isFacingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, rangoDeteccion);
    }
}


